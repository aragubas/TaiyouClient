using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TaiyouClient.Models.Response
{
    public struct GenericResponse
    {
        [JsonProperty("message")]
        public string Message;
    }
}
