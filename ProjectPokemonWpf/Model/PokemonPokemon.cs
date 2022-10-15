using Newtonsoft.Json;

namespace ProjectPokemonWpf.Model
{
    public class PokemonPokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}