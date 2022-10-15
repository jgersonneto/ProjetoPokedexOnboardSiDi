using Newtonsoft.Json;

namespace ProjectPokemonWpf.Model
{
    public class OfficialArtwork
    {
        [JsonProperty("front_default")]
        public string Front_Default { get; set; }
    }
}