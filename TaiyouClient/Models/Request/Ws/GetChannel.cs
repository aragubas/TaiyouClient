using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TaiyouClient.Models.Request.Ws
{
    public class GetChannel
    {
        [JsonProperty("channel_id")]
        public string ChannelId;

        public GetChannel(string channelId)
        {
            ChannelId = channelId;
        }
    }
}
