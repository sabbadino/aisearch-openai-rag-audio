using System.Diagnostics.CodeAnalysis;

namespace backendnet.MscCopilotTypes;

[ExcludeFromCodeCoverage]

/// <summary>
/// Represents an embedded URL along with its title and associated document name.
/// </summary>
public class EmbedUrl
{
    /// <summary>
    /// Gets the embedded URL as a string.
    /// </summary>
    public string Url { get; init; } = "";

    /// <summary>
    /// Gets the title associated with the embedded URL.
    /// </summary>
    public string Title { get; init; } = "";

    /// <summary>
    /// Gets the name of the document associated with the embedded URL.
    /// </summary>
    public string DocumentName { get; init; } = "";
}