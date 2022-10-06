using Newtonsoft.Json;

namespace ProjectPokemonUwp.Model
{
    public class AbilityElement
    {
        [JsonProperty("ability")]
        public TypeClass Ability { get; set; }
    }
}
