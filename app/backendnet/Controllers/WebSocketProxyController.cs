using Azure.AI.OpenAI;
using Microsoft.AspNetCore.Mvc;
using OpenAI;
using System.Net.WebSockets;
using System.Text;
using OpenAI.RealtimeConversation;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.Core;
using System.Net.Sockets;
using System;
using Azure;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;
#pragma warning disable OPENAI002

namespace backendnet.Controllers
{
    public class WebSocketProxyController : ControllerBase
    {
       

        private readonly ILogger<WebSocketProxyController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IAiToClientMessageProcessors _aiToClientMessageProcessors;
        private readonly IClientToAiMessageProcessors _clientToAiMessageProcessors;

        public WebSocketProxyController(ILogger<WebSocketProxyController> logger, 
            IConfiguration configuration, IAiToClientMessageProcessors aiToClientMessageProcessors,
            IClientToAiMessageProcessors clientToAiMessageProcessors)
        {

            _logger = logger;
            _configuration = configuration;
            _aiToClientMessageProcessors = aiToClientMessageProcessors;
            _clientToAiMessageProcessors = clientToAiMessageProcessors;
        }

        [Route("/realtime")]
        public async Task Get()
        {

            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                try
                {
                    using var clientWebSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                
                    using var aiWebSocket = await ConnectToAi();
                    Console.WriteLine();
                    Console.WriteLine("connected");
                    Task.Run(async() =>
                    {
                        await AiToClientForwardLoop(new CommunicationContext { ClientWebSocket = clientWebSocket, AiWebSocket = aiWebSocket });

                    });
                    await ClientToAiForwardLoop(new CommunicationContext { ClientWebSocket = clientWebSocket, AiWebSocket = aiWebSocket });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error {ex}");
                    throw;
                }
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            
           
        }

        private async Task<ClientWebSocket> ConnectToAi()
        {
            var endpoint = _configuration["AZURE_OPENAI_ENDPOINT"];
            ArgumentException.ThrowIfNullOrEmpty(endpoint);
            var azureOpenAiApiKey = _configuration["AZURE_OPENAI_API_KEY"];
            ArgumentException.ThrowIfNullOrEmpty(azureOpenAiApiKey);
            var deployment = _configuration["AZURE_OPENAI_DEPLOYMENT"];
            ArgumentException.ThrowIfNullOrEmpty(deployment);
            var aiWebSocket = new ClientWebSocket();
            aiWebSocket.Options.SetRequestHeader("api-key", azureOpenAiApiKey);
            //?api-version=2024-10-01-preview&deployment=gpt-4o-realtime-preview-1001
            var url = $"{endpoint}/openai/realtime?api-version=2024-10-01-preview&deployment={deployment}";
            await aiWebSocket.ConnectAsync(new Uri(url),
                CancellationToken.None);
            return aiWebSocket;
        }

   

       
#pragma warning disable OPENAI002
          async Task ClientToAiForwardLoop(CommunicationContext communicationContext)

        {

            try
            {
                var open =true;
                do
                {
                    open = SocketsAreOpen(communicationContext);
                    if (open)
                    {
                        open = await _clientToAiMessageProcessors.ProcessAndForwardToAi(communicationContext);
                    }
                }
                while (open);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"AiToClientForwardError: {ex}");
                throw;
            }
           
        }

      
        bool SocketsAreOpen(CommunicationContext communicationContext )
        {
            if (communicationContext.ClientWebSocket.State == WebSocketState.Closed)
            {
                Console.WriteLine("clientWebSocket.State== WebSocketState.Closed. Exiting loop");
                return false;    
            }
            if(communicationContext.AiWebSocket.State == WebSocketState.Closed)
            {
                Console.WriteLine("aiWebSocket.State== WebSocketState.Closed. Exiting loop");
                return false;
            }
            return true;
        }

        async Task AiToClientForwardLoop(CommunicationContext communicationContext)
        {
            try
            {

                var open = true;
                do
                {
                    open = SocketsAreOpen(communicationContext);
                    if(open)
                    {
                        open = await _aiToClientMessageProcessors.ProcessAndForwardToClient(communicationContext);
                    }
                }
                while (open);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"AiToClientForwardError: {ex}");
            }
        }

       
    }
}
