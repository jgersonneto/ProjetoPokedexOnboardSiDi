using Newtonsoft.Json;

namespace ProjectPokemonUwp.Model
{
    public class PokemonPokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
