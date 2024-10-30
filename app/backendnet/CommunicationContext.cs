using System.Net.WebSockets;

namespace backendnet;

public class CommunicationContext
{
    
    public required WebSocket ClientWebSocket { get; init; }
    public required  WebSocket AiWebSocket { get; init; }
}