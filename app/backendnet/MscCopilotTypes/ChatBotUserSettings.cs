using System.Diagnostics.CodeAnalysis;

namespace backendnet.MscCopilotTypes;

[ExcludeFromCodeCoverage]

/// <summary>
/// Represents the configuration settings for a chatbot user.
/// </summary>
public class ChatBotUserSettings
{
    /// <summary>
    /// Indicates whether the chatbot is currently available for communication.
    /// </summary>
    /// <value>
    /// <c>true</c> if the chatbot is available; otherwise, <c>false</c>.
    /// </value>
    public bool Available { get; init; }

    /// <summary>
    /// The name or identifier of the deployment where the chatbot is hosted.
    /// </summary>
    /// <value>
    /// A string representing the deployment name.
    /// </value>
    public string DeploymentName { get; init; } = "";

    /// <summary>
    /// The maximum number of conversation history pairs (question-answer pairs) retained in memory 
    /// during a session.
    /// </summary>
    /// <value>
    /// An integer representing the maximum number of conversation history pairs.
    /// </value>
    public int MaxConversationHistoryPairsLength { get; init; }

    /// <summary>
    /// The maximum allowed length (in characters) for a user's question or query.
    /// </summary>
    /// <value>
    /// An integer representing the maximum length of user questions.
    /// </value>
    public int MaxAllowedUserQuestionLength { get; init; }
}


