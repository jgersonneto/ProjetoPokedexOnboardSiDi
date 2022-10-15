using Newtonsoft.Json;

namespace Connection.Dispatcher
{
    public class OfficialArtwork
    {
        public int Id { get; set; }

        [JsonProperty("front_default")]
        public string Front_Default { get; set; }
    }
}