namespace backendnet.Controllers;

public class RealTimeAudioSettings 
{
    public string SystemMessageName { get; init; } = "";
    public float Temperature { get; init; } = 0;

    public int MaxResponseOutputTokens { get; init; } = 1000;
}