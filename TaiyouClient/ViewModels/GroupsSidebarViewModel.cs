using Avalonia.Controls;
using Newtonsoft.Json;
using ReactiveUI;
using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using TaiyouClient.Models;
using TaiyouClient.Models.Response;

namespace TaiyouClient.ViewModels
{
    public class GroupsSidebarViewModel : ViewModelBase
    {
        public ObservableCollection<BasicGroupInfo> Groups { get; }
        public string Ceira = "sinas";

        void Ws_OnUpdateGroups(SocketIOResponse response)
        {
            Groups.Clear();
            GetGroupsResponse getGroupResponse = JsonConvert.DeserializeObject<GetGroupsResponse>(response.GetValue().GetRawText());

            foreach (BasicGroupInfo group in getGroupResponse.Groups)
            {
                Groups.Add(group);
            }
        }

        public GroupsSidebarViewModel()
        {
            //_groups.Clear();
            if (Groups == null)
            {
                Groups = new ObservableCollection<BasicGroupInfo>();
                //wsAPI.ConnectChangeEvent += ConnectChange;

                // Shows example data if in debug mode
#if DEBUG
                Groups.Add(new BasicGroupInfo() { Name = "Ceira", Id = "sdkfpasdkfasdf" });
                Groups.Add(new BasicGroupInfo() { Name = "Sinas", Id = "asdfjkaewqkjdw" });
                Groups.Add(new BasicGroupInfo() { Name = "Caldo de Pilha", Id = "sdfsodifjosidj" });
                Groups.Add(new BasicGroupInfo() { Name = "Sinas Express", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "sfgsdfsadf", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "234rwfsdg", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "cbvasrgdfg", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "wertsdfgdgsd", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "dghsdfgasdgfg", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "sdfwfsdf", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "fghjdfhdrth", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "asdsdfewr", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "xzcvdfgvdg", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "hrhfghfgh", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "ewer2345rwer", Id = "sdfsjdfoisodif" });
#endif

                wsAPI.client?.On("update_groups", Ws_OnUpdateGroups);
            }

        }
    }
}
