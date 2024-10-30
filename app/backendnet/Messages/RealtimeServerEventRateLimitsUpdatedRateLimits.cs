using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class RealtimeServerEventRateLimitsUpdatedRateLimits {
    /// <summary>
    /// The name of the rate limit (\"requests\", \"tokens\", \"input_tokens\", \"output_tokens\").
    /// </summary>
    /// <value>The name of the rate limit (\"requests\", \"tokens\", \"input_tokens\", \"output_tokens\").</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// The maximum allowed value for the rate limit.
    /// </summary>
    /// <value>The maximum allowed value for the rate limit.</value>
    [DataMember(Name="limit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The remaining value before the limit is reached.
    /// </summary>
    /// <value>The remaining value before the limit is reached.</value>
    [DataMember(Name="remaining", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "remaining")]
    public int? Remaining { get; set; }

    /// <summary>
    /// Seconds until the rate limit resets.
    /// </summary>
    /// <value>Seconds until the rate limit resets.</value>
    [DataMember(Name="reset_seconds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reset_seconds")]
    public decimal? ResetSeconds { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeServerEventRateLimitsUpdatedRateLimits {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Limit: ").Append(Limit).Append("\n");
      sb.Append("  Remaining: ").Append(Remaining).Append("\n");
      sb.Append("  ResetSeconds: ").Append(ResetSeconds).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
