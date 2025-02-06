using backendnet.Controllers;
using System.Net.WebSockets;
using System.Text;
using Microsoft.Extensions.Options;
using IO.Swagger.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Microsoft.AspNetCore.Components.Web;

namespace backendnet;

public interface IClientToAiMessageProcessors
{
    Task<bool> ProcessAndForwardToAi(CommunicationContext communicationContext);
}

public class ClientToAiMessageProcessors : IClientToAiMessageProcessors
{
    private readonly IMessageParser _messageParser;
    private readonly RealTimeAudioSettings _realTimeAudioSettings;

    public ClientToAiMessageProcessors(IOptions<RealTimeAudioSettings> realTimeAudioSettings, IMessageParser messageParser)
    {
        _messageParser = messageParser;
        _realTimeAudioSettings = realTimeAudioSettings.Value;
        _Handlers.Add("session.update", HandleSessionUpdate);
    }

    JsonSerializerSettings Opt = new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Ignore
    };
    private Dictionary<string, Func<JObject, byte[]>> _Handlers = new Dictionary<string, Func<JObject, byte[]>>();    
    byte[]? ClientToAiProcessMessage(byte[] buffer)
    {
        var command = _messageParser.GetCommandName(buffer);
        if (command == null) {
            return null;
        } 
        if(_Handlers.TryGetValue(command, out var handler)) {
            var message = _messageParser.GetJson(buffer, buffer.Length);
            if (message != null)
            {
                return handler(message);
            }
            return buffer;    
        }
        return buffer;
    }

    private byte[] HandleSessionUpdate(JObject message)
    {
        var functionName = AppConstants.FunctionName;
        var realtimeClientEventSessionUpdate = message.ToObject<RealtimeClientEventSessionUpdate>() ?? new();
        realtimeClientEventSessionUpdate.Session.Instructions = File.ReadAllText($"systemMessage-{_realTimeAudioSettings.SystemMessageName}.txt");
        realtimeClientEventSessionUpdate.Session.Temperature = Convert.ToDecimal(_realTimeAudioSettings.Temperature);
        realtimeClientEventSessionUpdate.Session.MaxResponseOutputTokens = _realTimeAudioSettings.MaxResponseOutputTokens;
        realtimeClientEventSessionUpdate.Session.ToolChoice = "auto";
        realtimeClientEventSessionUpdate.Session.Voice = "shimmer";
        realtimeClientEventSessionUpdate.Session.Tools =
        [
            new RealtimeClientEventSessionUpdateSessionTools
            {
                Description = File.ReadAllText($"{functionName}.txt"),
                Name = functionName ,
                Type ="function",
                Parameters = JObject.Parse(File.ReadAllText($"{functionName}.json"))
            }
        ];
        return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(realtimeClientEventSessionUpdate, Opt));
    }


    public async Task<bool> ProcessAndForwardToAi(CommunicationContext communicationContext)
    {
        var ms = new MemoryStream();
        var buffer = new byte[1024 * 4];
        var receiveResult = await communicationContext.ClientWebSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer), CancellationToken.None);
        if (receiveResult.MessageType == WebSocketMessageType.Close)
        {
            // ack the close to the client
            await communicationContext.ClientWebSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "client sent close request", CancellationToken.None);
            // Send close to server
            if (communicationContext.AiWebSocket.State == WebSocketState.Open)
            {
                await communicationContext.AiWebSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "client sent close request", CancellationToken.None);
            }
            var msg = receiveResult.CloseStatus != null ? receiveResult.CloseStatus.Value.ToString() : "";
            Console.WriteLine($"clientWebSocket returned {WebSocketMessageType.Close} {msg}");
            return false;
        }
        ms.Write(buffer, 0, receiveResult.Count);

        while (!receiveResult.EndOfMessage)
        {
            buffer = new byte[1024 * 4];
            receiveResult = await communicationContext.ClientWebSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);
            ms.Write(buffer, 0, receiveResult.Count);
        }

        buffer = ms.ToArray();

        
        buffer = ClientToAiProcessMessage(buffer);
        try
        {
            await communicationContext.AiWebSocket.SendAsync(
                new ArraySegment<byte>(buffer, 0, buffer.Length),
                receiveResult.MessageType,
                receiveResult.EndOfMessage,
                CancellationToken.None);

        }
        catch (Exception ex)
        {
            throw;
        }
        return true;
    }
}