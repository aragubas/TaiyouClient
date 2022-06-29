using Newtonsoft.Json;

namespace TaiyouClient.Models.Ws
{
    public struct GetMeResponse
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("username")]
        public string Username;

        [JsonProperty("full_name")]
        public string FullName;

    }
}
