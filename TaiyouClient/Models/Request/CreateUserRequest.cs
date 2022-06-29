using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaiyouClient.Models.Request
{
    public class CreateUserRequest
    {
        [JsonProperty("username")]
        public string Username;
        
        [JsonProperty("email")]
        public string Email;
        
        [JsonProperty("password")]
        public string Password;
        
        public CreateUserRequest(string Username, string Email, string Password)
        {
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;

        }
    }
}
