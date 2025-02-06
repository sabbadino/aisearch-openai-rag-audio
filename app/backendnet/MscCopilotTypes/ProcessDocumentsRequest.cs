using System.Diagnostics.CodeAnalysis;

namespace backendnet.MscCopilotTypes;
[ExcludeFromCodeCoverage]


/// <summary>
/// Represents the request details for processing documents, 
/// including data source information, a unique code, and execution options.
/// </summary>
public class ProcessDocumentsRequest
{
    /// <summary>
    /// Gets the name of the data source from which documents are processed.
    /// </summary>
    public string DataSourceName { get; init; } = "";

    /// <summary>
    /// Gets a unique code associated with the document processing request.
    /// </summary>
    public string Code { get; init; } = "";

    /// <summary>
    /// Indicates whether the MD5 check should be skipped during the upload process.
    /// </summary>
    public bool SkipMd5CheckOnUpload { get; set; }

    /// <summary>
    /// Indicates whether the request should be executed in a "fire-and-forget" mode,
    /// where the operation proceeds without waiting for completion.
    /// </summary>
    public bool ExecuteAsFireAndForget { get; set; }
}
