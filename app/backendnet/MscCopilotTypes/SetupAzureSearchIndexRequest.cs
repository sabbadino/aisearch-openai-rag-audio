namespace backendnet.MscCopilotTypes;

/// <summary>
/// Represents a request to set up an Azure Search index with the specified data source.
/// </summary>
public class SetupAzureSearchIndexRequest
{
    /// <summary>
    /// Gets the name of the data source to be used for configuring the Azure Search index.
    /// </summary>
    public string DataSourceName { get; init; } = "";
}