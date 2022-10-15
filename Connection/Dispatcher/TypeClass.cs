using Newtonsoft.Json;

namespace Connection.Dispatcher
{
    public class TypeClass
    {
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public string IconName { get; set; }
    }
}