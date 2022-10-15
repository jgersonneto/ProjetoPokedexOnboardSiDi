using Newtonsoft.Json;

namespace ProjectPokemonWpf.Model
{
    public class TypeClass
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        public string IconName { get; set; }
    }
}