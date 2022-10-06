using Newtonsoft.Json;

namespace ProjectPokemonUwp.Model
{
    public class TypeClass
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
