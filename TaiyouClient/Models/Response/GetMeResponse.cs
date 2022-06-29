using Newtonsoft.Json;

namespace TaiyouClient.Models.Response
{
    public struct GetMeResponse
    {
        [JsonProperty("message")]
        public string Message;

        [JsonProperty("access_token")]
        public string AccessToken;

        [JsonProperty("user_id")]
        public string UserID;

        [JsonProperty("username")]
        public string Username;
    }
}
