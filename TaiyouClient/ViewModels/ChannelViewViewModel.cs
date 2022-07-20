using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReactiveUI;
using SocketIOClient;
using TaiyouClient.Models;
using TaiyouClient.Models.Request.Ws;
using TaiyouClient.Models.Ws;

namespace TaiyouClient.ViewModels
{
    public class ChannelViewViewModel : ViewModelBase
    {
        ObservableCollection<Message> Messages { get; }

        BasicChannelInfo _info = new BasicChannelInfo() {  Id="1234567890abcdef", Name= "Channel" };
        public BasicChannelInfo Info
        {
            get => _info;
            set => this.RaiseAndSetIfChanged(ref _info, value);
        }

        bool _isLoading = true;
        public bool IsLoading
        {
            get => _isLoading;
            set => this.RaiseAndSetIfChanged(ref _isLoading, value);
        }

        void GetInitialMessages(SocketIOResponse response)
        {
            if (response.GetValue().GetRawText() == "\"not_found\"")
            {
                Console.WriteLine("ChannelVVM: Channel not found when requesting information about it from server.");
                return;
            }
            GetChannelResponse getChannelResponse = JsonConvert.DeserializeObject<GetChannelResponse>(response.GetValue().GetRawText());

            Messages.Clear();

            Console.WriteLine(response.GetValue().GetRawText());

            // Adds the messages
            getChannelResponse.Messages.ForEach((message) => { Messages.Add(message); });

            IsLoading = false;
        }

        public async void LoadChannel(BasicChannelInfo channel)
        {
            Info = channel;
            Messages.Clear();

            if (wsAPI.client != null && wsAPI.client.Connected)
            {
                await wsAPI.client.EmitAsync("get_channel", GetInitialMessages, JsonConvert.SerializeObject(new GetChannel(channel.Id)));
            }

        }

        public ChannelViewViewModel()
        {            
            Messages = new();

            Messages.Add(new Message() { Id = "abcdef0123456789", Content = "Test", Date = DateTime.Now, ChannelId = "abc123", OwnerUsername = "TestUser" });
            Messages.Add(new Message() { Id = "0123456789abcdef", Content = "Test 2", Date = DateTime.Now, ChannelId = "abc123", OwnerUsername = "TestUser" });
            Messages.Add(new Message() { Id = "0123456789ghijkl", Content = "Test 3", Date = DateTime.Now, ChannelId = "abc123", OwnerUsername = "TestUser" });
        }
    }
}
