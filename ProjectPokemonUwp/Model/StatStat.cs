using Newtonsoft.Json;

namespace ProjectPokemonUwp.Model
{
    public class StatStat
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
