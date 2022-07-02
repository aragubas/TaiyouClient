using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SocketIOClient;
using TaiyouClient.Models.Ws;

namespace TaiyouClient
{
    public static class wsAPI
    {
        public static SocketIO client;
        public delegate void ConnectChange(bool newState);
        public static event ConnectChange ConnectChangeEvent;

        public async static void Connect()
        {
            if (client != null) { return; }

            SocketIOOptions options = new();
            options.ExtraHeaders = new Dictionary<string, string>();
            options.ExtraHeaders.Add("x-auth-token", API.CurrentUser.AccessToken);

            client = new SocketIO("ws://localhost:3313", options);
            client.OnConnected += Client_OnConnected;
            client.OnDisconnected += Client_OnDisconnected;
            client.On("auth_success", Client_AuthSuccess);
            client.On("credential_error", Client_CredentialsError);

            await client.ConnectAsync();
            await client.EmitAsync("check_auth");
            await client.EmitAsync("get_groups");

        }

        private static void Client_OnDisconnected(object? sender, string e)
        {
            ConnectChangeEvent?.Invoke(false);
        }

        private static void Client_OnConnected(object? sender, EventArgs e)
        {
            Console.WriteLine("Websocket OnConnected");
        }

        static void Client_AuthSuccess(SocketIOResponse response)
        {
            Console.WriteLine("Authenticated Successfully!");

            GetMeResponse getMe = JsonConvert.DeserializeObject<GetMeResponse>(response.GetValue().GetRawText());

            // Check if the stored user needs to be updated
            if (API.CurrentUser.Username != getMe.Username || API.CurrentUser.UserID != getMe.Id || API.CurrentUser.FullName != getMe.FullName)
            {
                API.CurrentUser.Username = getMe.Username;
                API.CurrentUser.FullName = getMe.FullName;
                API.CurrentUser.UserID = getMe.Id;
                API.UpdateStoredUser();
            }

            ConnectChangeEvent?.Invoke(true);


        }

        static void Client_CredentialsError(SocketIOResponse response)
        {
            Console.WriteLine("Credentials Error!");
            ConnectChangeEvent?.Invoke(false);

        }

    }
}
