using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaiyouClient.Models.Ws
{
    public struct GetChannelResponse
    {
        [JsonProperty("messages")]
        public List<Message> Messages;

        [JsonProperty("name")]
        public string Name;
    }
}
