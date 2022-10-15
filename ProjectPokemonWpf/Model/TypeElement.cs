using Newtonsoft.Json;

namespace ProjectPokemonWpf.Model
{
    public class TypeElement
    {
        [JsonProperty("type")]
        public TypeClass Type { get; set; }
    }
}