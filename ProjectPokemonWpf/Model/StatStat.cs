using Newtonsoft.Json;

namespace ProjectPokemonWpf.Model
{
    public class StatStat
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}