using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaiyouClient.Models
{
    public struct Message
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("ownerUsername")]
        public string OwnerUsername { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("channelID")]
        public string ChannelId { get; set; }
    }
}
