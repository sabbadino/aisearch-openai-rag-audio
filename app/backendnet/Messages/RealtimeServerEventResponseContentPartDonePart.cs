using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// The content part that is done.
  /// </summary>
  [DataContract]
  public class RealtimeServerEventResponseContentPartDonePart {
    /// <summary>
    /// The content type (\"text\", \"audio\").
    /// </summary>
    /// <value>The content type (\"text\", \"audio\").</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// The text content (if type is \"text\").
    /// </summary>
    /// <value>The text content (if type is \"text\").</value>
    [DataMember(Name="text", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "text")]
    public string Text { get; set; }

    /// <summary>
    /// Base64-encoded audio data (if type is \"audio\").
    /// </summary>
    /// <value>Base64-encoded audio data (if type is \"audio\").</value>
    [DataMember(Name="audio", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "audio")]
    public string Audio { get; set; }

    /// <summary>
    /// The transcript of the audio (if type is \"audio\").
    /// </summary>
    /// <value>The transcript of the audio (if type is \"audio\").</value>
    [DataMember(Name="transcript", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "transcript")]
    public string Transcript { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeServerEventResponseContentPartDonePart {\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Text: ").Append(Text).Append("\n");
      sb.Append("  Audio: ").Append(Audio).Append("\n");
      sb.Append("  Transcript: ").Append(Transcript).Append("\n");
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
