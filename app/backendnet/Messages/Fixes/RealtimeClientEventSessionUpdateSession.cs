using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace IO.Swagger.Model

{
    public partial class RealtimeClientEventSessionUpdateSession
    {
        [DataMember(Name = "max_response_output_tokens", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "max_response_output_tokens")]
        public int MaxResponseOutputTokens { get; set; }
    }
}
