using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Details of the error.
  /// </summary>
  [DataContract]
  public class RealtimeServerEventErrorError {
    /// <summary>
    /// The type of error (e.g., \"invalid_request_error\", \"server_error\").
    /// </summary>
    /// <value>The type of error (e.g., \"invalid_request_error\", \"server_error\").</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Error code, if any.
    /// </summary>
    /// <value>Error code, if any.</value>
    [DataMember(Name="code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "code")]
    public string Code { get; set; }

    /// <summary>
    /// A human-readable error message.
    /// </summary>
    /// <value>A human-readable error message.</value>
    [DataMember(Name="message", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "message")]
    public string Message { get; set; }

    /// <summary>
    /// Parameter related to the error, if any.
    /// </summary>
    /// <value>Parameter related to the error, if any.</value>
    [DataMember(Name="param", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "param")]
    public string Param { get; set; }

    /// <summary>
    /// The event_id of the client event that caused the error, if applicable.
    /// </summary>
    /// <value>The event_id of the client event that caused the error, if applicable.</value>
    [DataMember(Name="event_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "event_id")]
    public string EventId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeServerEventErrorError {\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Code: ").Append(Code).Append("\n");
      sb.Append("  Message: ").Append(Message).Append("\n");
      sb.Append("  Param: ").Append(Param).Append("\n");
      sb.Append("  EventId: ").Append(EventId).Append("\n");
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
