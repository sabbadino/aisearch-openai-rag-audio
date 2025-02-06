using System.Diagnostics.CodeAnalysis;

namespace backendnet.MscCopilotTypes
{
    /// <summary>
    /// Answer to user model which will be sent to the user as a response.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AnswerToUserDto
    {
        /*
         * 
         */
        public string Answer { get; set; } = "";

        /// <summary>
        /// A unique identifier for the conversation related to this answer.
        /// </summary>
        public Guid ConversationId { get; set; } = Guid.Empty;

        /// <summary>
        /// Denotes the language code of the user's question (e.g., "en" for English).
        /// </summary>
        public string QuestionLanguageCode { get; set; } = "";

        /// <summary>
        /// A list of URLs containing embedded resources relevant to the user's query
        /// or the response provided.
        /// </summary>
        public List<EmbedUrl> EmbedUrls { get; init; } = new();

        /// <summary>
        /// Represents the status of the response using an enumeration.
        /// This is useful for identifying whether the response was successful
        /// or if there were specific errors.
        /// </summary>
        public AnswerStatusCode StatusCode { get; set; }

        /// <summary>
        /// A unique identifier for the given answer.
        /// This can help in tracking or debugging specific responses.
        /// </summary>
        public Guid AnswerId { get; set; } = Guid.Empty;

        /// <summary>
        /// Defines a suggested voice for text-to-speech functionality when
        /// presenting the answer to the user.
        /// </summary>
        public string SuggestedSpeakVoice { get; set; } = "";

        /// <summary>
        /// Describes the status of the answer or any associated errors.
        /// This is a required field to provide a clear description of the response state.
        /// </summary>
        public required string StatusCodeDescription { get; init; }

        /// <summary>
        /// Denotes the agent used to process the user's question.
        /// Useful in multi-agent systems to identify the agent involved.
        /// </summary>
        public string SelectedAgent { get; set; } = "";

        /// <summary>
        /// Specifies the name of the function, if applicable, associated with generating this response.
        /// This information can help trace the logic used to formulate the answer.
        /// </summary>
        public string FunctionName { get; set; } = "";
    }

    /// <summary>
    /// Enum representing the status codes for the AnswerToUserDto model.
    /// These statuses describe the outcome or issues encountered during response generation.
    /// </summary>
    public enum AnswerStatusCode
    {
        /// <summary>
        /// Indicates a successful response to the user.
        /// </summary>
        Ok,

        /// <summary>
        /// Model is either restricted or no user-specific configuration exists for the model.
        /// </summary>
        NoModelAllowedForUsersOrConfiguredModelForUserNotFound,

        /// <summary>
        /// Indicates that the user has exceeded the chat completion usage limit.
        /// </summary>
        OutOfChatCompletionQuotaLimit,

        /// <summary>
        /// Indicates that the user has exceeded the rate limit for chat completion requests.
        /// </summary>
        OutOfChatCompletionRateLimit,

        /// <summary>
        /// The request to generate an answer was malformed or invalid.
        /// </summary>
        BadRequest,

        /// <summary>
        /// An error occurred on the server while processing the request.
        /// </summary>
        InternalServerError,

        /// <summary>
        /// An error occurred while trying to load embedding data or resources.
        /// </summary>
        ErrorLoadingEmbeddings,
    }
}