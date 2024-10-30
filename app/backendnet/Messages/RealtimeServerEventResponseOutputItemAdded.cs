using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Returned when a new Item is created during response generation.
  /// </summary>
  [DataContract]
  public class RealtimeServerEventResponseOutputItemAdded {
    /// <summary>
    /// The unique ID of the server event.
    /// </summary>
    /// <value>The unique ID of the server event.</value>
    [DataMember(Name="event_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "event_id")]
    public string EventId { get; set; }

    /// <summary>
    /// The event type, must be \"response.output_item.added\".
    /// </summary>
    /// <value>The event type, must be \"response.output_item.added\".</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// The ID of the response to which the item belongs.
    /// </summary>
    /// <value>The ID of the response to which the item belongs.</value>
    [DataMember(Name="response_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "response_id")]
    public string ResponseId { get; set; }

    /// <summary>
    /// The index of the output item in the response.
    /// </summary>
    /// <value>The index of the output item in the response.</value>
    [DataMember(Name="output_index", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "output_index")]
    public int? OutputIndex { get; set; }

    /// <summary>
    /// Gets or Sets Item
    /// </summary>
    [DataMember(Name="item", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "item")]
    public RealtimeServerEventResponseOutputItemAddedItem Item { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeServerEventResponseOutputItemAdded {\n");
      sb.Append("  EventId: ").Append(EventId).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  ResponseId: ").Append(ResponseId).Append("\n");
      sb.Append("  OutputIndex: ").Append(OutputIndex).Append("\n");
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
