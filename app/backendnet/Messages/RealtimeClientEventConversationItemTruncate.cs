using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Send this event when you want to truncate a previous assistant message’s audio.
  /// </summary>
  [DataContract]
  public class RealtimeClientEventConversationItemTruncate {
    /// <summary>
    /// Optional client-generated ID used to identify this event.
    /// </summary>
    /// <value>Optional client-generated ID used to identify this event.</value>
    [DataMember(Name="event_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "event_id")]
    public string EventId { get; set; }

    /// <summary>
    /// The event type, must be \"conversation.item.truncate\".
    /// </summary>
    /// <value>The event type, must be \"conversation.item.truncate\".</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// The ID of the assistant message item to truncate.
    /// </summary>
    /// <value>The ID of the assistant message item to truncate.</value>
    [DataMember(Name="item_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "item_id")]
    public string ItemId { get; set; }

    /// <summary>
    /// The index of the content part to truncate.
    /// </summary>
    /// <value>The index of the content part to truncate.</value>
    [DataMember(Name="content_index", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "content_index")]
    public int? ContentIndex { get; set; }

    /// <summary>
    /// Inclusive duration up to which audio is truncated, in milliseconds.
    /// </summary>
    /// <value>Inclusive duration up to which audio is truncated, in milliseconds.</value>
    [DataMember(Name="audio_end_ms", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "audio_end_ms")]
    public int? AudioEndMs { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeClientEventConversationItemTruncate {\n");
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
