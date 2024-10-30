using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Returned when an input audio buffer is committed, either by the client or automatically in server VAD mode.
  /// </summary>
  [DataContract]
  public class RealtimeServerEventInputAudioBufferCommitted {
    /// <summary>
    /// The unique ID of the server event.
    /// </summary>
    /// <value>The unique ID of the server event.</value>
    [DataMember(Name="event_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "event_id")]
    public string EventId { get; set; }

    /// <summary>
    /// The event type, must be \"input_audio_buffer.committed\".
    /// </summary>
    /// <value>The event type, must be \"input_audio_buffer.committed\".</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// The ID of the preceding item after which the new item will be inserted.
    /// </summary>
    /// <value>The ID of the preceding item after which the new item will be inserted.</value>
    [DataMember(Name="previous_item_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "previous_item_id")]
    public string PreviousItemId { get; set; }

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
      sb.Append("class RealtimeServerEventInputAudioBufferCommitted {\n");
      sb.Append("  EventId: ").Append(EventId).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  PreviousItemId: ").Append(PreviousItemId).Append("\n");
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
