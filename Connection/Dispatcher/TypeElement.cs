using Newtonsoft.Json;

namespace Connection.Dispatcher
{
    public class TypeElement
    {
        public int Id { get; set; }

        [JsonProperty("type")]
        public TypeClass Type { get; set; }
    }
}