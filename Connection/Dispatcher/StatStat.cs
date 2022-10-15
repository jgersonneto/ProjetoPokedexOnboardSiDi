using Newtonsoft.Json;

namespace Connection.Dispatcher
{
    public class StatStat
    {
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}