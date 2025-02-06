namespace backendnet.MscCopilotTypes;

/// <summary>
/// Defines the operations for managing chat-related functionality, 
/// such as handling user questions, providing feedback, and interacting with chat user settings.
/// </summary>
public interface IChatController
{
    /// <summary>
    /// Retrieves a list of available functions with their details.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="FunctionsCallDto"/> objects.</returns>
    Task<List<FunctionsCallDto>> ListFunctions();

    /// <summary>
    /// Processes a user question and streams the results back.
    /// </summary>
    /// <param name="userQuestionDto">The user question data transfer object containing the question details.</param>
    /// <returns>A task that represents the asynchronous streaming operation.</returns>
    Task AskStreamed(UserQuestionDto? userQuestionDto);

    /// <summary>
    /// Processes a user question and returns an answer.
    /// </summary>
    /// <param name="userQuestion">The user question data transfer object containing the question details.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="AnswerToUserDto"/> with the answer details.</returns>
    Task<AnswerToUserDto> Ask(UserQuestionDto userQuestion);

    /// <summary>
    /// Sets feedback for a provided answer.
    /// </summary>
    /// <param name="feedbackToAnswer">The feedback data transfer object containing feedback details.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="FeedbackToAnswerResponse"/> indicating the result of the operation.</returns>
    Task<FeedbackToAnswerResponse> SetFeedback(FeedbackToAnswer feedbackToAnswer);

    /// <summary>
    /// Retrieves the chat bot settings for the current user.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="ChatBotUserSettings"/> object with the user's settings.</returns>
    Task<ChatBotUserSettings> GetChatBotUserSettings();

    /// <summary>
    /// Fetches a token for speech synthesis or recognition functionality.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="SpeechTokenResponse"/> with the speech token details.</returns>
    Task<SpeechTokenResponse> GetSpeechToken();
}