using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// The conversation resource.
  /// </summary>
  [DataContract]
  public class RealtimeServerEventConversationCreatedConversation {
    /// <summary>
    /// The unique ID of the conversation.
    /// </summary>
    /// <value>The unique ID of the conversation.</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// The object type, must be \"realtime.conversation\".
    /// </summary>
    /// <value>The object type, must be \"realtime.conversation\".</value>
    [DataMember(Name="object", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "object")]
    public string _Object { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeServerEventConversationCreatedConversation {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  _Object: ").Append(_Object).Append("\n");
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
