using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemonWpf.Model
{
    public class Types
    {
        [JsonProperty("pokemon")]
        public List<PokemonElement> Pokemon { get; set; }
    }
}
