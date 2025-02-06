namespace backendnet.MscCopilotTypes;

/// <summary>
/// Represents data related to a function call, including its name, description, and parameters.
/// </summary>
public class FunctionsCallDto
{
    /// <summary>
    /// Gets the name of the function being called.
    /// </summary>
    public string FunctionName { get; init; } = "";

    /// <summary>
    /// Gets the description of the function being called.
    /// </summary>
    public string FunctionDescription { get; init; } = "";

    /// <summary>
    /// Gets the parameters associated with the function call in string format.
    /// </summary>
    public string FunctionParameters { get; init; } = "";
}