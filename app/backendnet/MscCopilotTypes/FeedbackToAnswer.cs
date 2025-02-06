using System.Diagnostics.CodeAnalysis;

namespace backendnet.MscCopilotTypes;

[ExcludeFromCodeCoverage]

/// <summary>
/// Represents the user feedback to an answer.
/// </summary>
public class FeedbackToAnswer
{

    /// <summary>
    /// user id as an uniqe identification
    /// </summary>
    public Guid AnswerId { get; init; }

    /// <summary>
    /// user feedback
    /// </summary>
    public Feedback Feedback { get; init; } = Feedback.None;
}

public enum Feedback
{
    None = 0,
    Up = 1,
    Down = -1
}