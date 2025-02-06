using System.Diagnostics.CodeAnalysis;

namespace backendnet.MscCopilotTypes
{
    [ExcludeFromCodeCoverage]

    /// <summary>
    /// Represents the data transfer object for a user's question, including 
    /// the conversation ID and the question text.
    /// </summary>
    public class UserQuestionDto
    {
        /// <summary>
        /// Gets the unique identifier for the conversation associated with the question.
        /// </summary>
        public Guid ConversationId { get; init; } = Guid.NewGuid();

        /// <summary>
        /// Gets the text of the question asked by the user.
        /// </summary>
        public required string Question { get; init; } = "";
    }
}