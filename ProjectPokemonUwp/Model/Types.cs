using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProjectPokemonUwp.Model
{
    public class Types
    {
        [JsonProperty("pokemon")]
        public List<PokemonElement> Pokemon { get; set; }
    }
}
