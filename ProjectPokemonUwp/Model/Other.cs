using Newtonsoft.Json;

namespace ProjectPokemonUwp.Model
{
    public class Other
    {
        [JsonProperty("dream_world")]
        public DreamWorld Dream_World { get; set; }

        [JsonProperty("home")]
        public Home Home { get; set; }

        [JsonProperty("official-artwork")]
        public OfficialArtwork OfficialArtwork { get; set; }
    }
}
