using Newtonsoft.Json;

namespace ProjectPokemonUwp.Model
{
    public class PokemonElement
    {
        [JsonProperty("pokemon")]
        public PokemonPokemon Pokemon { get; set; }
    }
}
