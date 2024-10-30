using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Configuration for the response.
  /// </summary>
  [DataContract]
  public class RealtimeClientEventResponseCreateResponse {
    /// <summary>
    /// The modalities for the response.
    /// </summary>
    /// <value>The modalities for the response.</value>
    [DataMember(Name="modalities", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modalities")]
    public List<string> Modalities { get; set; }

    /// <summary>
    /// Instructions for the model.
    /// </summary>
    /// <value>Instructions for the model.</value>
    [DataMember(Name="instructions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "instructions")]
    public string Instructions { get; set; }

    /// <summary>
    /// The voice the model uses to respond - one of `alloy`, `echo`, or `shimmer`.
    /// </summary>
    /// <value>The voice the model uses to respond - one of `alloy`, `echo`, or `shimmer`.</value>
    [DataMember(Name="voice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "voice")]
    public string Voice { get; set; }

    /// <summary>
    /// The format of output audio.
    /// </summary>
    /// <value>The format of output audio.</value>
    [DataMember(Name="output_audio_format", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "output_audio_format")]
    public string OutputAudioFormat { get; set; }

    /// <summary>
    /// Tools (functions) available to the model.
    /// </summary>
    /// <value>Tools (functions) available to the model.</value>
    [DataMember(Name="tools", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tools")]
    public List<RealtimeClientEventResponseCreateResponseTools> Tools { get; set; }

    /// <summary>
    /// How the model chooses tools.
    /// </summary>
    /// <value>How the model chooses tools.</value>
    [DataMember(Name="tool_choice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tool_choice")]
    public string ToolChoice { get; set; }

    /// <summary>
    /// Sampling temperature.
    /// </summary>
    /// <value>Sampling temperature.</value>
    [DataMember(Name="temperature", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "temperature")]
    public decimal? Temperature { get; set; }

    /// <summary>
    /// Maximum number of output tokens for a single assistant response, inclusive of tool calls. Provide an integer between 1 and 4096 to limit output tokens, or \"inf\" for the maximum available tokens for a given model. Defaults to \"inf\".
    /// </summary>
    /// <value>Maximum number of output tokens for a single assistant response, inclusive of tool calls. Provide an integer between 1 and 4096 to limit output tokens, or \"inf\" for the maximum available tokens for a given model. Defaults to \"inf\".</value>
    [DataMember(Name="max_output_tokens", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "max_output_tokens")]
    public OneOfRealtimeClientEventResponseCreateResponseMaxOutputTokens MaxOutputTokens { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeClientEventResponseCreateResponse {\n");
      sb.Append("  Modalities: ").Append(Modalities).Append("\n");
      sb.Append("  Instructions: ").Append(Instructions).Append("\n");
      sb.Append("  Voice: ").Append(Voice).Append("\n");
      sb.Append("  OutputAudioFormat: ").Append(OutputAudioFormat).Append("\n");
      sb.Append("  Tools: ").Append(Tools).Append("\n");
      sb.Append("  ToolChoice: ").Append(ToolChoice).Append("\n");
      sb.Append("  Temperature: ").Append(Temperature).Append("\n");
      sb.Append("  MaxOutputTokens: ").Append(MaxOutputTokens).Append("\n");
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
