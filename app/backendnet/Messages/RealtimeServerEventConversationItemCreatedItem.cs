using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// The item that was created.
  /// </summary>
  [DataContract]
  public class RealtimeServerEventConversationItemCreatedItem {
    /// <summary>
    /// The unique ID of the item.
    /// </summary>
    /// <value>The unique ID of the item.</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// The object type, must be \"realtime.item\".
    /// </summary>
    /// <value>The object type, must be \"realtime.item\".</value>
    [DataMember(Name="object", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "object")]
    public string _Object { get; set; }

    /// <summary>
    /// The type of the item (\"message\", \"function_call\", \"function_call_output\").
    /// </summary>
    /// <value>The type of the item (\"message\", \"function_call\", \"function_call_output\").</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// The status of the item (\"completed\", \"in_progress\", \"incomplete\").
    /// </summary>
    /// <value>The status of the item (\"completed\", \"in_progress\", \"incomplete\").</value>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public string Status { get; set; }

    /// <summary>
    /// The role associated with the item (\"user\", \"assistant\", \"system\").
    /// </summary>
    /// <value>The role associated with the item (\"user\", \"assistant\", \"system\").</value>
    [DataMember(Name="role", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "role")]
    public string Role { get; set; }

    /// <summary>
    /// The content of the item.
    /// </summary>
    /// <value>The content of the item.</value>
    [DataMember(Name="content", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "content")]
    public List<RealtimeServerEventConversationItemCreatedItemContent> Content { get; set; }

    /// <summary>
    /// The ID of the function call (for \"function_call\" items).
    /// </summary>
    /// <value>The ID of the function call (for \"function_call\" items).</value>
    [DataMember(Name="call_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "call_id")]
    public string CallId { get; set; }

    /// <summary>
    /// The name of the function being called.
    /// </summary>
    /// <value>The name of the function being called.</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// The arguments of the function call.
    /// </summary>
    /// <value>The arguments of the function call.</value>
    [DataMember(Name="arguments", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "arguments")]
    public string Arguments { get; set; }

    /// <summary>
    /// The output of the function call (for \"function_call_output\" items).
    /// </summary>
    /// <value>The output of the function call (for \"function_call_output\" items).</value>
    [DataMember(Name="output", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "output")]
    public string Output { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeServerEventConversationItemCreatedItem {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  _Object: ").Append(_Object).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  Role: ").Append(Role).Append("\n");
      sb.Append("  Content: ").Append(Content).Append("\n");
      sb.Append("  CallId: ").Append(CallId).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Arguments: ").Append(Arguments).Append("\n");
      sb.Append("  Output: ").Append(Output).Append("\n");
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
