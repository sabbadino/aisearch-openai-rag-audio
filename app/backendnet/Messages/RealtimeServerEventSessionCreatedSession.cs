using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// The session resource.
  /// </summary>
  [DataContract]
  public class RealtimeServerEventSessionCreatedSession {
    /// <summary>
    /// The unique ID of the session.
    /// </summary>
    /// <value>The unique ID of the session.</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// The object type, must be \"realtime.session\".
    /// </summary>
    /// <value>The object type, must be \"realtime.session\".</value>
    [DataMember(Name="object", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "object")]
    public string _Object { get; set; }

    /// <summary>
    /// The default model used for this session.
    /// </summary>
    /// <value>The default model used for this session.</value>
    [DataMember(Name="model", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "model")]
    public string Model { get; set; }

    /// <summary>
    /// The set of modalities the model can respond with.
    /// </summary>
    /// <value>The set of modalities the model can respond with.</value>
    [DataMember(Name="modalities", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modalities")]
    public List<string> Modalities { get; set; }

    /// <summary>
    /// The default system instructions.
    /// </summary>
    /// <value>The default system instructions.</value>
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
    /// The format of input audio.
    /// </summary>
    /// <value>The format of input audio.</value>
    [DataMember(Name="input_audio_format", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "input_audio_format")]
    public string InputAudioFormat { get; set; }

    /// <summary>
    /// The format of output audio.
    /// </summary>
    /// <value>The format of output audio.</value>
    [DataMember(Name="output_audio_format", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "output_audio_format")]
    public string OutputAudioFormat { get; set; }

    /// <summary>
    /// Gets or Sets InputAudioTranscription
    /// </summary>
    [DataMember(Name="input_audio_transcription", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "input_audio_transcription")]
    public RealtimeServerEventSessionCreatedSessionInputAudioTranscription InputAudioTranscription { get; set; }

    /// <summary>
    /// Gets or Sets TurnDetection
    /// </summary>
    [DataMember(Name="turn_detection", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "turn_detection")]
    public RealtimeServerEventSessionCreatedSessionTurnDetection TurnDetection { get; set; }

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
    /// Maximum number of output tokens.
    /// </summary>
    /// <value>Maximum number of output tokens.</value>
    [DataMember(Name="max_output_tokens", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "max_output_tokens")]
    public OneOfRealtimeServerEventSessionCreatedSessionMaxOutputTokens MaxOutputTokens { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeServerEventSessionCreatedSession {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  _Object: ").Append(_Object).Append("\n");
      sb.Append("  Model: ").Append(Model).Append("\n");
      sb.Append("  Modalities: ").Append(Modalities).Append("\n");
      sb.Append("  Instructions: ").Append(Instructions).Append("\n");
      sb.Append("  Voice: ").Append(Voice).Append("\n");
      sb.Append("  InputAudioFormat: ").Append(InputAudioFormat).Append("\n");
      sb.Append("  OutputAudioFormat: ").Append(OutputAudioFormat).Append("\n");
      sb.Append("  InputAudioTranscription: ").Append(InputAudioTranscription).Append("\n");
      sb.Append("  TurnDetection: ").Append(TurnDetection).Append("\n");
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
