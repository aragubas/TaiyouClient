using Newtonsoft.Json;

namespace TaiyouClient.Models.ConfigFile
{
    public class CurrentUserModel
    {
        [JsonProperty("access_token")]
        public string AccessToken;

        [JsonProperty("user_id")]
        public string UserID;

        [JsonProperty("username")]
        public string Username;

        public CurrentUserModel(string AccessToken, string UserID, string Username)
        {
            this.AccessToken = AccessToken;
            this.UserID = UserID;
            this.Username = Username;
        }
    }
}
