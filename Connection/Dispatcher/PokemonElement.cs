using Newtonsoft.Json;

namespace Connection.Dispatcher
{
    public class PokemonElement
    {
        public int Id { get; set; }

        [JsonProperty("pokemon")]
        public PokemonPokemon Pokemon { get; set; }
    }
}