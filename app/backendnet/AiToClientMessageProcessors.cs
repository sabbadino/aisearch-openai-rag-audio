using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure;
using backendnet.Controllers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenAI.RealtimeConversation;
using static System.Net.Mime.MediaTypeNames;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace backendnet;
public interface IAiToClientMessageProcessors
{
    Task<bool> ProcessAndForwardToClient(CommunicationContext communicationContext);
}
public class AiToClientMessageProcessors : IAiToClientMessageProcessors
{
    private readonly IMessageParser _messageParser;
    private readonly IWeatherProvider _weatherProvider;
    private readonly RealTimeAudioSettings _realTimeAudioSettings;

    public AiToClientMessageProcessors(IOptions<RealTimeAudioSettings> realTimeAudioSettings, IMessageParser messageParser, IWeatherProvider weatherProvider)
    {
        _messageParser = messageParser;
        _weatherProvider = weatherProvider;
        _realTimeAudioSettings = realTimeAudioSettings.Value;
    }
    private static readonly JsonSerializerOptions Opt = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
    };
    private static readonly Encoding Utf8Encoding = Encoding.UTF8;
    private Dictionary<string, RTToolCall> _tools_pending = new ();
    async Task<byte[]?> AiToClientProcessMessage(JObject message,CommunicationContext communicationContext)
    {
        var type = message["type"]?.Value<string>();
        switch (type)
        {
            case "error":
                Console.WriteLine(message.ToString());
                break;
            case "response.function_call_arguments.delta":
                return null;
            case "response.function_call_arguments.done":
                return null;

            case "response.output_item.done":
                await HandleResponseOutputItemAdded(message, communicationContext);
                break;
            case "response.output_item.added":
                if (HandleResponseOutputItemAdded(message)) return null;
                break;

            case "response.done":
                await HandleResponseDone(message, communicationContext);

                break;

            case "conversation.item.created":
                if (HandleConversationItemCreated(message)) return null;
                break;
            case "session.created":
                HandleSessionCreated(message);
                break;
            case "session.error":
                break;
            default:
                // do nothing , pass through
                break;
        }
        return Utf8Encoding.GetBytes(message.ToString());
    }

    private static void HandleSessionCreated(JObject message)
    {
        var session = message["session"]!;
        //# Hide the instructions, tools and max tokens from clients, if we ever allow client-side 
        //# tools, this will need updating
        session["instructions"] = "";
        session["tools"] = null;
        session["tool_choice"] = "none";
        session["max_response_output_tokens"] = null;
    }

    private bool HandleConversationItemCreated(JObject message)
    {
        if (message["item"] is { } item1)
        {
            if (item1["type"]?.Value<string>() == "function_call")
            {
                if (item1["call_id"]?.Value<string>() is { } callId)
                {
                    if (!_tools_pending.ContainsKey(callId))
                    {
                        var v = new RTToolCall
                            { tool_call_id = callId, previous_id = message["previous_item_id"]?.Value<string>() ?? null };
                        _tools_pending.Add(callId, v);
                    }
                }

                return true;
            }
            else if (item1["type"]?.Value<string>() == "function_call_output")
            {
                return true;
            }
        }

        return false;
    }

    private async Task HandleResponseOutputItemAdded(JObject message, CommunicationContext communicationContext)
    {
        if (message["item"] is { } itemd && itemd["type"]?.Value<string>() == "function_call")
        {
            if (itemd["call_id"]?.Value<string>() is { } callId1)
            {
                if (_tools_pending.TryGetValue(callId1, out var rTToolCall))
                {
                    var toolName = itemd["name"]?.Value<string>();
                    if (toolName == "get-current-weather")
                    {
                        if (itemd["arguments"]?.Value<string>() is { } args)
                        {
                            var input = JsonSerializer.Deserialize<GetCurrentWeatherRequest>(args, Opt);
                            if (input == null)
                            {
                                Console.WriteLine($"input = JsonSerializer.Deserialize<GetCurrentWeatherRequest>({args})==null");
                            }
                            else
                            {
                                var text = "";
                                try
                                {
                                    var response = await _weatherProvider.WeatherStackCurrent(input);
                                    text = JsonEncodedText.Encode(JsonSerializer.Serialize(response)).Value;
                                    // this is to make appear the data as text in the ui .. but currently it expects the format 
                                    // of a result from azure ai search
                                    //var msg = new
                                    //{
                                    //    type = "extension.middle_tier_tool_response",
                                    //    previous_item_id = rTToolCall.previous_id,
                                    //    tool_name = toolName,
                                    //    tool_result = JsonConvert.SerializeObject(response)
                                    //};
                                    //var buffer1 = Utf8Encoding.GetBytes(JsonConvert.SerializeObject(msg));
                                    //await communicationContext.ClientWebSocket.SendAsync(
                                    //    new ArraySegment<byte>(buffer1, 0, buffer1.Length),
                                    //    WebSocketMessageType.Text,
                                    //    true,
                                    //    CancellationToken.None);
                                }
                                catch (Exception ex) {
                                    text = JsonEncodedText.Encode(JsonSerializer.Serialize(new { Result = "KO", Reason = ex.Message })).Value;

                                }
                                var buffer = GenerateFunctionCallOutput(callId1, text);
                                await communicationContext.AiWebSocket.SendAsync(
                                    new ArraySegment<byte>(buffer, 0, buffer.Length),
                                    WebSocketMessageType.Text,
                                    true,
                                    CancellationToken.None
                                );
                               


                            }
                        }
                        else
                        {
                            Console.WriteLine("args == null");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unknown function call {toolName}");
                    }
                }
            }
        }
    }

    private static bool HandleResponseOutputItemAdded(JObject message)
    {
        if (message["item"] is { } item && item["type"]?.Value<string>() == "function_call")
        {
            return true;
        }

        return false;
    }

    private async Task HandleResponseDone(JObject message, CommunicationContext communicationContext)
    {
        if (_tools_pending.Count > 0)
        {
            _tools_pending.Clear();
            var buffer = GenerateResponseCreate();
            await communicationContext.AiWebSocket.SendAsync(
                new ArraySegment<byte>(buffer, 0, buffer.Length),
                WebSocketMessageType.Text,
                true,
                CancellationToken.None
            );
        }

        if (message["response"] is { } responsew && responsew["output"] is JArray items)
        {
            var x= items.ToList();
            x.RemoveAll(itemx =>
            {
                if (itemx["type"]?.Value<string>() is { } typex && typex == "function_call")
                {
                    return true;
                }
                return false;
            });
        }
    }

    private static byte[] GenerateResponseCreate()
    {
        var templatec = """
                        {
                           "type": "response.create"
                        }
                        """;
        var buffer = Utf8Encoding.GetBytes(templatec);
        return buffer;
    }

    private static byte[] GenerateFunctionCallOutput(string callId1, string text)
    {
        var template = """
                       {
                           "type": "conversation.item.create",
                           "item": {
                               "type": "function_call_output",
                               "call_id": "{{call_id}}",
                               "output": "{{output}}"
                           }
                       }
                       """;

        template = template.Replace("{{call_id}}", callId1);
        template = template.Replace("{{output}}", text);
        var buffer = Utf8Encoding.GetBytes(template);
        return buffer;
    }

    public class RTToolCall {
        public string tool_call_id { get; init; }
        public string? previous_id { get; init; }
    }
    
    public async Task<bool> ProcessAndForwardToClient(CommunicationContext communicationContext)
    {

        var ms = new MemoryStream();
        var buffer = new byte[1024 * 4];
        var receiveResult = await communicationContext.AiWebSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer), CancellationToken.None);
        if (receiveResult.MessageType == WebSocketMessageType.Close)
        {
            // forward to client the close request. for a server socket calling close is ok 
            if (communicationContext.ClientWebSocket.State == WebSocketState.Open)
            {
                await communicationContext.ClientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "client sent close request", CancellationToken.None);
            }
            // ack the AI we close the socket 
            await communicationContext.AiWebSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "client sent close request", CancellationToken.None);
            var msg = receiveResult.CloseStatus != null ? receiveResult.CloseStatus.Value.ToString() : "";
            Console.WriteLine($"aiWebSocket returned {WebSocketMessageType.Close} {msg}");
            return false;
        }
        ms.Write(buffer, 0, receiveResult.Count);
        while (!receiveResult.EndOfMessage)
        {
            buffer = new byte[1024 * 4];
            receiveResult = await communicationContext.AiWebSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);
            ms.Write(buffer, 0, receiveResult.Count);

        }



        buffer = ms.ToArray();

        var jObject = _messageParser.GetJson(buffer, buffer.Length);
        if (jObject != null)
        {
            buffer= await AiToClientProcessMessage(jObject,communicationContext);
            if (buffer != null)
            {
                await communicationContext.ClientWebSocket.SendAsync(
                    new ArraySegment<byte>(buffer, 0, buffer.Length),
                    receiveResult.MessageType,
                    receiveResult.EndOfMessage,
                    CancellationToken.None);
            }
            return true;
        }
        return true;
    }


  
}