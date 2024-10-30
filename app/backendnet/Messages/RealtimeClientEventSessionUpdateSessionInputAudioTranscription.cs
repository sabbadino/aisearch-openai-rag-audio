using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Configuration for input audio transcription. Can be set to &#x60;null&#x60; to turn off.
  /// </summary>
  [DataContract]
  public class RealtimeClientEventSessionUpdateSessionInputAudioTranscription {
    /// <summary>
    /// The model to use for transcription (e.g., \"whisper-1\").
    /// </summary>
    /// <value>The model to use for transcription (e.g., \"whisper-1\").</value>
    [DataMember(Name="model", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "model")]
    public string Model { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeClientEventSessionUpdateSessionInputAudioTranscription {\n");
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
