using System;
using System.Collections.Generic;
using ReactiveUI;
using System.Collections.ObjectModel;
using TaiyouClient.Models;
using TaiyouClient.Models.Ws;

namespace TaiyouClient.ViewModels
{
    public class GroupViewViewModel : ViewModelBase
    {
        ObservableCollection<BasicChannelInfo> Channels { get; }

        int _membersCount = 666;
        public int MembersCount
        {
            get => _membersCount;
            set => this.RaiseAndSetIfChanged(ref _membersCount, value);
        }

        string _name = "Unnamed Group";
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

        public void LoadGroupData(GetGroupInfoResponse groupInfo)
        {
            MembersCount = groupInfo.MembersCount;
            Name = groupInfo.Name;
            Id = groupInfo.Id;

            Channels.Clear();
            foreach (BasicChannelInfo channel in groupInfo.Channels)
            {
                Channels.Add(channel);
            }
        }

        public GroupViewViewModel()
        {
            if (Channels == null)
            {
                Channels = new ObservableCollection<BasicChannelInfo>();

                // Adds test data in debug environment
#if DEBUG
                Channels.Add(new BasicChannelInfo() { Name = "Sinas", Id = "sdfjaosdifasdf" });
                Channels.Add(new BasicChannelInfo() { Name = "Ceira", Id = "asdfasdfasdfasdf" });
                Channels.Add(new BasicChannelInfo() { Name = "Caldo_de_Pilha", Id = "sadfawgtaergasdf" });
                Channels.Add(new BasicChannelInfo() { Name = "Nuerbas", Id = "fgasdfwawerawef" });
                Channels.Add(new BasicChannelInfo() { Name = "Catrelas", Id = "sgasfeawefawe" });
                Channels.Add(new BasicChannelInfo() { Name = "Sinas", Id = "sdfjaosdifasdf" });
                Channels.Add(new BasicChannelInfo() { Name = "Ceira", Id = "asdfasdfasdfasdf" });
                Channels.Add(new BasicChannelInfo() { Name = "Caldo_de_Pilha", Id = "sadfawgtaergasdf" });
                Channels.Add(new BasicChannelInfo() { Name = "Nuerbas", Id = "fgasdfwawerawef" });
                Channels.Add(new BasicChannelInfo() { Name = "Catrelas", Id = "sgasfeawefawe" });
                Channels.Add(new BasicChannelInfo() { Name = "Sinas", Id = "sdfjaosdifasdf" });
                Channels.Add(new BasicChannelInfo() { Name = "Ceira", Id = "asdfasdfasdfasdf" });
                Channels.Add(new BasicChannelInfo() { Name = "Caldo_de_Pilha", Id = "sadfawgtaergasdf" });
                Channels.Add(new BasicChannelInfo() { Name = "Nuerbas", Id = "fgasdfwawerawef" });
                Channels.Add(new BasicChannelInfo() { Name = "Catrelas", Id = "sgasfeawefawe" });
#endif

            }
        }

    }
}
