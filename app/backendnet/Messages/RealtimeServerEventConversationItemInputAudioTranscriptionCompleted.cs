using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Returned when input audio transcription is enabled and a transcription succeeds.
  /// </summary>
  [DataContract]
  public class RealtimeServerEventConversationItemInputAudioTranscriptionCompleted {
    /// <summary>
    /// The unique ID of the server event.
    /// </summary>
    /// <value>The unique ID of the server event.</value>
    [DataMember(Name="event_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "event_id")]
    public string EventId { get; set; }

    /// <summary>
    /// The event type, must be \"conversation.item.input_audio_transcription.completed\".
    /// </summary>
    /// <value>The event type, must be \"conversation.item.input_audio_transcription.completed\".</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// The ID of the user message item.
    /// </summary>
    /// <value>The ID of the user message item.</value>
    [DataMember(Name="item_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "item_id")]
    public string ItemId { get; set; }

    /// <summary>
    /// The index of the content part containing the audio.
    /// </summary>
    /// <value>The index of the content part containing the audio.</value>
    [DataMember(Name="content_index", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "content_index")]
    public int? ContentIndex { get; set; }

    /// <summary>
    /// The transcribed text.
    /// </summary>
    /// <value>The transcribed text.</value>
    [DataMember(Name="transcript", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "transcript")]
    public string Transcript { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeServerEventConversationItemInputAudioTranscriptionCompleted {\n");
      sb.Append("  EventId: ").Append(EventId).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  ItemId: ").Append(ItemId).Append("\n");
      sb.Append("  ContentIndex: ").Append(ContentIndex).Append("\n");
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
