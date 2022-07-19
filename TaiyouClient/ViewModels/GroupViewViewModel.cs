using System;
using System.Collections.Generic;
using ReactiveUI;
using System.Collections.ObjectModel;
using TaiyouClient.Models;
using TaiyouClient.Models.Ws;
using SocketIOClient;
using TaiyouClient.Models.Request.Ws;
using Newtonsoft.Json;
using Avalonia.Controls;
using TaiyouClient.Views.MainAreaViews.GroupViewViews;

namespace TaiyouClient.ViewModels
{
    public class GroupViewViewModel : ViewModelBase
    {
        public ObservableCollection<BasicChannelInfo> Channels { get; }

        Control _currentContent;
        public Control CurrentContent
        {
            get => _currentContent;
            set => this.RaiseAndSetIfChanged(ref _currentContent, value);
        }

        int _membersCount = 0;
        public int MembersCount
        {
            get => _membersCount;
            set => this.RaiseAndSetIfChanged(ref _membersCount, value);
        }

        string _name = "Loading...";
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        string _id;
        public string Id
        {
            get => _id;
            set => this.RaiseAndSetIfChanged(ref _id, value);
        }

        bool _isLoading = true;
        public bool IsLoading
        {
            get => _isLoading;
            set => this.RaiseAndSetIfChanged(ref _isLoading, value);
        }

        void LoadGroupData(GetGroupInfoResponse groupInfo)
        {
            MembersCount = groupInfo.MembersCount;
            Name = groupInfo.Name;

            Channels.Clear();
            foreach (BasicChannelInfo channel in groupInfo.Channels)
            {
                Channels.Add(channel);
            }

            IsLoading = false;
        }

        void WsUpdateGroup(SocketIOResponse response)
        {
            GetGroupInfoResponse groupsResponse = JsonConvert.DeserializeObject<GetGroupInfoResponse>(response.GetValue().GetRawText());
            LoadGroupData(groupsResponse);
        }

        public async void LoadGroup(string GroupId)
        {
            Channels?.Clear();
            IsLoading = true;
            _id = GroupId;

            if (wsAPI.client != null && wsAPI.client.Connected)
            {
                Channels?.Clear();
                await wsAPI.client.EmitAsync("get_group_info", JsonConvert.SerializeObject(new GetGroupInfo(GroupId)));

                wsAPI.client.On($"update_group:{GroupId}", WsUpdateGroup);
            }

        }

        public GroupViewViewModel()
        {
            if (Channels == null)
            {
                Channels = new ObservableCollection<BasicChannelInfo>();
                Channels.Add(new BasicChannelInfo() { Name = "Unknown Channel", Id = "1234567890abcdef" });


                //                //Adds test data in debug environment
                //#if DEBUG
                //                Channels.Add(new BasicChannelInfo() { Name = "Sinas", Id = "sdfjaosdifasdf" });
                //                Channels.Add(new BasicChannelInfo() { Name = "Ceira", Id = "asdfasdfasdfasdf" });
                //                Channels.Add(new BasicChannelInfo() { Name = "Caldo_de_Pilha", Id = "sadfawgtaergasdf" });
                //                Channels.Add(new BasicChannelInfo() { Name = "Nuerbas", Id = "fgasdfwawerawef" });
                //                Channels.Add(new BasicChannelInfo() { Name = "Catrelas", Id = "sgasfeawefawe" });
                //                Channels.Add(new BasicChannelInfo() { Name = "Sinas", Id = "sdfjaosdifasdf" });
                //                Channels.Add(new BasicChannelInfo() { Name = "Ceira", Id = "asdfasdfasdfasdf" });
                //                Channels.Add(new BasicChannelInfo() { Name = "Caldo_de_Pilha", Id = "sadfawgtaergasdf" });
                //                Channels.Add(new BasicChannelInfo() { Name = "Nuerbas", Id = "fgasdfwawerawef" });
                //                Channels.Add(new BasicChannelInfo() { Name = "Catrelas", Id = "sgasfeawefawe" });
                //                Channels.Add(new BasicChannelInfo() { Name = "Sinas", Id = "sdfjaosdifasdf" });
                //                Channels.Add(new BasicChannelInfo() { Name = "Ceira", Id = "asdfasdfasdfasdf" });
                //                Channels.Add(new BasicChannelInfo() { Name = "Caldo_de_Pilha", Id = "sadfawgtaergasdf" });
                //                Channels.Add(new BasicChannelInfo() { Name = "Nuerbas", Id = "fgasdfwawerawef" });
                //                Channels.Add(new BasicChannelInfo() { Name = "Catrelas", Id = "sgasfeawefawe" });
                //#endif


            }
        }

    }
}
