using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Configuration for turn detection.
  /// </summary>
  [DataContract]
  public class RealtimeServerEventSessionCreatedSessionTurnDetection {
    /// <summary>
    /// The type of turn detection (\"server_vad\" or \"none\").
    /// </summary>
    /// <value>The type of turn detection (\"server_vad\" or \"none\").</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Activation threshold for VAD.
    /// </summary>
    /// <value>Activation threshold for VAD.</value>
    [DataMember(Name="threshold", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "threshold")]
    public decimal? Threshold { get; set; }

    /// <summary>
    /// Audio included before speech starts (in milliseconds).
    /// </summary>
    /// <value>Audio included before speech starts (in milliseconds).</value>
    [DataMember(Name="prefix_padding_ms", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "prefix_padding_ms")]
    public int? PrefixPaddingMs { get; set; }

    /// <summary>
    /// Duration of silence to detect speech stop (in milliseconds).
    /// </summary>
    /// <value>Duration of silence to detect speech stop (in milliseconds).</value>
    [DataMember(Name="silence_duration_ms", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "silence_duration_ms")]
    public int? SilenceDurationMs { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeServerEventSessionCreatedSessionTurnDetection {\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Threshold: ").Append(Threshold).Append("\n");
      sb.Append("  PrefixPaddingMs: ").Append(PrefixPaddingMs).Append("\n");
      sb.Append("  SilenceDurationMs: ").Append(SilenceDurationMs).Append("\n");
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
