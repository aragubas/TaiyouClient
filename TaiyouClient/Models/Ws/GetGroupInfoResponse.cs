using Newtonsoft.Json;
using System.Collections.Generic;

namespace TaiyouClient.Models.Ws
{
    public struct GetGroupInfoResponse
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("channels")]
        public List<BasicChannelInfo> Channels;

        [JsonProperty("permissionString")]
        public string PermissionString;

        [JsonProperty("membersCount")]
        public int MembersCount;

    }
}
