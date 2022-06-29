using Newtonsoft.Json;

namespace TaiyouClient.Models.Request.Ws
{
    public class GetGroupInfo
    {
        [JsonProperty("group_id")]
        public string GroupId;

        public GetGroupInfo(string GroupId)
        {
            this.GroupId = GroupId;
        }
    }
}
