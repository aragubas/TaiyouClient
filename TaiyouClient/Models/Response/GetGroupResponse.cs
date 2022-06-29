using Newtonsoft.Json;

namespace TaiyouClient.Models.Response
{
    public struct GetGroupResponse
    {
        [JsonProperty("groups")]
        public BasicGroupInfo[] Groups;
    }
}
