using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Send this event to update the session’s default configuration.
  /// </summary>
  [DataContract]
  public class RealtimeClientEventSessionUpdate {
    /// <summary>
    /// Optional client-generated ID used to identify this event.
    /// </summary>
    /// <value>Optional client-generated ID used to identify this event.</value>
    [DataMember(Name="event_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "event_id")]
    public string EventId { get; set; }

    /// <summary>
    /// The event type, must be \"session.update\".
    /// </summary>
    /// <value>The event type, must be \"session.update\".</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Session
        /// </summary>
        [DataMember(Name = "session", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "session")]
        public RealtimeClientEventSessionUpdateSession Session { get; set; } = new();


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RealtimeClientEventSessionUpdate {\n");
      sb.Append("  EventId: ").Append(EventId).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Session: ").Append(Session).Append("\n");
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
