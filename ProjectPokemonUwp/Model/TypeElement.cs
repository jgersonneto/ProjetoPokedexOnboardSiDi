using Newtonsoft.Json;

namespace ProjectPokemonUwp.Model
{
    public class TypeElement
    {
        [JsonProperty("type")]
        public TypeClass Type { get; set; }
    }
}
