using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Returned in server turn detection mode when speech stops.
  /// </summary>
  [DataContract]
  public class RealtimeServerEventInputAudioBufferSpeechStopped {
    /// <summary>
    /// The unique ID of the server event.
    /// </summary>
    /// <value>The unique ID of the server event.</value>
    [DataMember(Name="event_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "event_id")]
    public string EventId { get; set; }

    /// <summary>
    /// The event type, must be \"input_audio_buffer.speech_stopped\".
    /// </summary>
    /// <value>The event type, must be \"input_audio_buffer.speech_stopped\".</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Milliseconds since the session started when speech stopped.
    /// </summary>
    /// <value>Milliseconds since the session started when speech stopped.</value>
    [DataMember(Name="audio_end_ms", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "audio_end_ms")]
    public int? AudioEndMs { get; set; }

    /// <summary>
    /// The ID of the user message item that will be created.
    /// </summary>
    /// <value>The ID of the user message item that will be created.</value>
    [DataMember(Name="item_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "item_id")]
    public string ItemId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeServerEventInputAudioBufferSpeechStopped {\n");
      sb.Append("  EventId: ").Append(EventId).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  AudioEndMs: ").Append(AudioEndMs).Append("\n");
      sb.Append("  ItemId: ").Append(ItemId).Append("\n");
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
