using Newtonsoft.Json;

namespace Connection.Dispatcher
{
    public class Other
    {
        public int Id { get; set; }

        [JsonProperty("dream_world")]
        public DreamWorld Dream_World { get; set; }

        [JsonProperty("home")]
        public Home Home { get; set; }

        [JsonProperty("official-artwork")]
        public OfficialArtwork OfficialArtwork { get; set; }
    }
}