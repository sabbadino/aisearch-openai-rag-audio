using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Returned when an earlier assistant audio message item is truncated by the client.
  /// </summary>
  [DataContract]
  public class RealtimeServerEventConversationItemTruncated {
    /// <summary>
    /// The unique ID of the server event.
    /// </summary>
    /// <value>The unique ID of the server event.</value>
    [DataMember(Name="event_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "event_id")]
    public string EventId { get; set; }

    /// <summary>
    /// The event type, must be \"conversation.item.truncated\".
    /// </summary>
    /// <value>The event type, must be \"conversation.item.truncated\".</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// The ID of the assistant message item that was truncated.
    /// </summary>
    /// <value>The ID of the assistant message item that was truncated.</value>
    [DataMember(Name="item_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "item_id")]
    public string ItemId { get; set; }

    /// <summary>
    /// The index of the content part that was truncated.
    /// </summary>
    /// <value>The index of the content part that was truncated.</value>
    [DataMember(Name="content_index", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "content_index")]
    public int? ContentIndex { get; set; }

    /// <summary>
    /// The duration up to which the audio was truncated, in milliseconds.
    /// </summary>
    /// <value>The duration up to which the audio was truncated, in milliseconds.</value>
    [DataMember(Name="audio_end_ms", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "audio_end_ms")]
    public int? AudioEndMs { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeServerEventConversationItemTruncated {\n");
      sb.Append("  EventId: ").Append(EventId).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  ItemId: ").Append(ItemId).Append("\n");
      sb.Append("  ContentIndex: ").Append(ContentIndex).Append("\n");
      sb.Append("  AudioEndMs: ").Append(AudioEndMs).Append("\n");
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
