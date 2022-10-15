using Newtonsoft.Json;

namespace ProjectPokemonWpf.Model
{
    public class AbilityElement
    {
        [JsonProperty("ability")]
        public TypeClass Ability { get; set; }
    }
}