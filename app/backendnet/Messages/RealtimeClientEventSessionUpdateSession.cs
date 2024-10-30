using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {
  
/// <summary>
    /// Session configuration to update.
    /// </summary>
    [DataContract]
  public partial class RealtimeClientEventSessionUpdateSession {
    /// <summary>
    /// The set of modalities the model can respond with. To disable audio, set this to [\"text\"].
    /// </summary>
    /// <value>The set of modalities the model can respond with. To disable audio, set this to [\"text\"].</value>
    [DataMember(Name="modalities", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modalities")]
    public List<string> Modalities { get; set; }

    /// <summary>
    /// The default system instructions prepended to model calls.
    /// </summary>
    /// <value>The default system instructions prepended to model calls.</value>
    [DataMember(Name="instructions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "instructions")]
    public string Instructions { get; set; }

    /// <summary>
    /// The voice the model uses to respond - one of `alloy`, `echo`, or  `shimmer`. Cannot be changed once the model has responded with audio  at least once.
    /// </summary>
    /// <value>The voice the model uses to respond - one of `alloy`, `echo`, or  `shimmer`. Cannot be changed once the model has responded with audio  at least once.</value>
    [DataMember(Name="voice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "voice")]
    public string Voice { get; set; }

    /// <summary>
    /// The format of input audio. Options are \"pcm16\", \"g711_ulaw\", or \"g711_alaw\".
    /// </summary>
    /// <value>The format of input audio. Options are \"pcm16\", \"g711_ulaw\", or \"g711_alaw\".</value>
    [DataMember(Name="input_audio_format", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "input_audio_format")]
    public string InputAudioFormat { get; set; }

    /// <summary>
    /// The format of output audio. Options are \"pcm16\", \"g711_ulaw\", or \"g711_alaw\".
    /// </summary>
    /// <value>The format of output audio. Options are \"pcm16\", \"g711_ulaw\", or \"g711_alaw\".</value>
    [DataMember(Name="output_audio_format", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "output_audio_format")]
    public string OutputAudioFormat { get; set; }

    /// <summary>
    /// Gets or Sets InputAudioTranscription
    /// </summary>
    [DataMember(Name="input_audio_transcription", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "input_audio_transcription")]
    public RealtimeClientEventSessionUpdateSessionInputAudioTranscription InputAudioTranscription { get; set; }

    /// <summary>
    /// Gets or Sets TurnDetection
    /// </summary>
    [DataMember(Name="turn_detection", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "turn_detection")]
    public RealtimeClientEventSessionUpdateSessionTurnDetection TurnDetection { get; set; }

    /// <summary>
    /// Tools (functions) available to the model.
    /// </summary>
    /// <value>Tools (functions) available to the model.</value>
    [DataMember(Name="tools", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tools")]
    public List<RealtimeClientEventSessionUpdateSessionTools> Tools { get; set; }

    /// <summary>
    /// How the model chooses tools. Options are \"auto\", \"none\", \"required\", or specify a function.
    /// </summary>
    /// <value>How the model chooses tools. Options are \"auto\", \"none\", \"required\", or specify a function.</value>
    [DataMember(Name="tool_choice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tool_choice")]
    public string ToolChoice { get; set; }

    /// <summary>
    /// Sampling temperature for the model.
    /// </summary>
    /// <value>Sampling temperature for the model.</value>
    [DataMember(Name="temperature", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "temperature")]
    public decimal? Temperature { get; set; }

    
    /// <summary>
    /// Maximum number of output tokens for a single assistant response, inclusive of tool calls. Provide an integer between 1 and 4096 to limit output tokens, or \"inf\" for the maximum available tokens for a given model. Defaults to \"inf\".
    /// </summary>
    /// <value>Maximum number of output tokens for a single assistant response, inclusive of tool calls. Provide an integer between 1 and 4096 to limit output tokens, or \"inf\" for the maximum available tokens for a given model. Defaults to \"inf\".</value>
    [DataMember(Name="max_output_tokens", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "max_output_tokens")]
    public OneOfRealtimeClientEventSessionUpdateSessionMaxOutputTokens MaxOutputTokens { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeClientEventSessionUpdateSession {\n");
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
