using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Returned when the model-generated function call arguments are updated.
  /// </summary>
  [DataContract]
  public class RealtimeServerEventResponseFunctionCallArgumentsDelta {
    /// <summary>
    /// The unique ID of the server event.
    /// </summary>
    /// <value>The unique ID of the server event.</value>
    [DataMember(Name="event_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "event_id")]
    public string EventId { get; set; }

    /// <summary>
    /// The event type, must be \"response.function_call_arguments.delta\".
    /// </summary>
    /// <value>The event type, must be \"response.function_call_arguments.delta\".</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// The ID of the response.
    /// </summary>
    /// <value>The ID of the response.</value>
    [DataMember(Name="response_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "response_id")]
    public string ResponseId { get; set; }

    /// <summary>
    /// The ID of the function call item.
    /// </summary>
    /// <value>The ID of the function call item.</value>
    [DataMember(Name="item_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "item_id")]
    public string ItemId { get; set; }

    /// <summary>
    /// The index of the output item in the response.
    /// </summary>
    /// <value>The index of the output item in the response.</value>
    [DataMember(Name="output_index", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "output_index")]
    public int? OutputIndex { get; set; }

    /// <summary>
    /// The ID of the function call.
    /// </summary>
    /// <value>The ID of the function call.</value>
    [DataMember(Name="call_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "call_id")]
    public string CallId { get; set; }

    /// <summary>
    /// The arguments delta as a JSON string.
    /// </summary>
    /// <value>The arguments delta as a JSON string.</value>
    [DataMember(Name="delta", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "delta")]
    public string Delta { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeServerEventResponseFunctionCallArgumentsDelta {\n");
      sb.Append("  EventId: ").Append(EventId).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  ResponseId: ").Append(ResponseId).Append("\n");
      sb.Append("  ItemId: ").Append(ItemId).Append("\n");
      sb.Append("  OutputIndex: ").Append(OutputIndex).Append("\n");
      sb.Append("  CallId: ").Append(CallId).Append("\n");
      sb.Append("  Delta: ").Append(Delta).Append("\n");
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
