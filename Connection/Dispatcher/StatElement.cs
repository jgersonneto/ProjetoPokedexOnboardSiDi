using Newtonsoft.Json;

namespace Connection.Dispatcher
{
    public class StatElement
    {
        public int Id { get; set; }

        [JsonProperty("base_stat")]
        public int Base_Stat { get; set; }

        [JsonProperty("stat")]
        public StatStat Stat { get; set; }
    }
}