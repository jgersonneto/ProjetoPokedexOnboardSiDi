using Newtonsoft.Json;

namespace ProjectPokemonUwp.Model
{
    public class OfficialArtwork
    {
        [JsonProperty("front_default")]
        public string Front_Default { get; set; }
    }
}
