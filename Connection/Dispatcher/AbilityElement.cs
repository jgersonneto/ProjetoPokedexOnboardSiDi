using Newtonsoft.Json;

namespace Connection.Dispatcher
{
    public class AbilityElement
    {
        public int Id { get; set; }

        [JsonProperty("ability")]
        public TypeClass Ability { get; set; }
    }
}