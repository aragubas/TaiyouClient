using Newtonsoft.Json;

namespace TaiyouClient.Models.Response
{
    public struct GetGroupsResponse
    {
        [JsonProperty("groups")]
        public BasicGroupInfo[] Groups;
    }
}
