namespace backendnet.MscCopilotTypes;


/// <summary>
/// Represents the response containing a speech token and its associated region.
/// </summary>
public class SpeechTokenResponse
{
    /// <summary>
    /// Gets the speech token used for authentication or interaction with speech services.
    /// </summary>
    public string Token { get; init; } = "";

    /// <summary>
    /// Gets the region associated with the speech token.
    /// </summary>
    public string Region { get; init; } = "";
}