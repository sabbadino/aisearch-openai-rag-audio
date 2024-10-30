using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Returned in server turn detection mode when speech is detected.
  /// </summary>
  [DataContract]
  public class RealtimeServerEventInputAudioBufferSpeechStarted {
    /// <summary>
    /// The unique ID of the server event.
    /// </summary>
    /// <value>The unique ID of the server event.</value>
    [DataMember(Name="event_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "event_id")]
    public string EventId { get; set; }

    /// <summary>
    /// The event type, must be \"input_audio_buffer.speech_started\".
    /// </summary>
    /// <value>The event type, must be \"input_audio_buffer.speech_started\".</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Milliseconds since the session started when speech was detected.
    /// </summary>
    /// <value>Milliseconds since the session started when speech was detected.</value>
    [DataMember(Name="audio_start_ms", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "audio_start_ms")]
    public int? AudioStartMs { get; set; }

    /// <summary>
    /// The ID of the user message item that will be created when speech stops.
    /// </summary>
    /// <value>The ID of the user message item that will be created when speech stops.</value>
    [DataMember(Name="item_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "item_id")]
    public string ItemId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeServerEventInputAudioBufferSpeechStarted {\n");
      sb.Append("  EventId: ").Append(EventId).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  AudioStartMs: ").Append(AudioStartMs).Append("\n");
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
