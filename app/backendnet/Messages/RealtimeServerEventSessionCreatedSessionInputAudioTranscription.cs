using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Configuration for input audio transcription.
  /// </summary>
  [DataContract]
  public class RealtimeServerEventSessionCreatedSessionInputAudioTranscription {
    /// <summary>
    /// Whether input audio transcription is enabled.
    /// </summary>
    /// <value>Whether input audio transcription is enabled.</value>
    [DataMember(Name="enabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// The model used for transcription.
    /// </summary>
    /// <value>The model used for transcription.</value>
    [DataMember(Name="model", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "model")]
    public string Model { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeServerEventSessionCreatedSessionInputAudioTranscription {\n");
      sb.Append("  Enabled: ").Append(Enabled).Append("\n");
      sb.Append("  Model: ").Append(Model).Append("\n");
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
