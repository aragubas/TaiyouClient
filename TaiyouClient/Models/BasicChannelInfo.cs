using Newtonsoft.Json;

namespace TaiyouClient.Models
{
    public struct BasicChannelInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("channelName")]
        public string Name { get; set; }
    }
}
