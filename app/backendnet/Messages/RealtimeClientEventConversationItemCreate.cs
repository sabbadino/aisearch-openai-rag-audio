using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Send this event when adding an item to the conversation.
  /// </summary>
  [DataContract]
  public class RealtimeClientEventConversationItemCreate {
    /// <summary>
    /// Optional client-generated ID used to identify this event.
    /// </summary>
    /// <value>Optional client-generated ID used to identify this event.</value>
    [DataMember(Name="event_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "event_id")]
    public string EventId { get; set; }

    /// <summary>
    /// The event type, must be \"conversation.item.create\".
    /// </summary>
    /// <value>The event type, must be \"conversation.item.create\".</value>
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
    /// Gets or Sets Item
    /// </summary>
    [DataMember(Name="item", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "item")]
    public RealtimeClientEventConversationItemCreateItem Item { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeClientEventConversationItemCreate {\n");
      sb.Append("  EventId: ").Append(EventId).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  PreviousItemId: ").Append(PreviousItemId).Append("\n");
      sb.Append("  Item: ").Append(Item).Append("\n");
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
