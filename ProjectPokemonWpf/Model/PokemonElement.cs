using Newtonsoft.Json;

namespace ProjectPokemonWpf.Model
{
    public class PokemonElement
    {
        [JsonProperty("pokemon")]
        public PokemonPokemon Pokemon { get; set; }
    }
}