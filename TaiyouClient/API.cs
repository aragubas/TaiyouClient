using System;
using System.IO;
using Newtonsoft.Json;
using SocketIOClient;
using System.Net.Http;
using TaiyouClient.Models.ConfigFile;

namespace TaiyouClient
{
    public static class API
    {
        public static readonly HttpClient client = new();
        public static CurrentUserModel CurrentUser = new("", "", "");

        // 🗣💥
        public static string EnceirarJson(string Input)
        {
            return Input.Remove(0, 1).Remove(Input.Length - 2, 1);
        }

        public static void UpdateStoredUser()
        {
            string fileContent = JsonConvert.SerializeObject(CurrentUser);
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aragubas", "TaiyouClient");

            Directory.CreateDirectory(path);

            File.WriteAllText(Path.Combine(path, "credentials.json"), fileContent);
        }

        public static bool LoadStoredUser()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aragubas", "TaiyouClient", "credentials.json");
            
            // Returns false if file doesn't exist
            if (!File.Exists(filePath)) { return false; }

            string fileContents = File.ReadAllText(filePath);

            try
            {
                CurrentUserModel storedUser = JsonConvert.DeserializeObject<CurrentUserModel>(fileContents);

                CurrentUser = storedUser;

                return true;

            } catch (JsonReaderException)
            {
                return false;
            }

        }
    }
}
