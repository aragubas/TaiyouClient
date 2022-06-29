using Newtonsoft.Json;
using ReactiveUI;
using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaiyouClient.Models;
using TaiyouClient.Models.Response;

namespace TaiyouClient.ViewModels
{
    public class GroupsSidebarViewModel : ViewModelBase
    {
        public ObservableCollection<BasicGroupInfo> Groups { get; }

        void Ws_OnUpdateGroups(SocketIOResponse response)
        {
            Console.WriteLine("Update Groups");
            Console.WriteLine(response.GetValue().GetRawText());
            Groups.Clear();
            GetGroupResponse getGroupResponse = JsonConvert.DeserializeObject<GetGroupResponse>(response.GetValue().GetRawText());

            foreach (BasicGroupInfo group in getGroupResponse.Groups)
            {
                Groups.Add(group);
            }
        }

        void ConnectChange(bool newState)
        {
            Console.WriteLine($"State change: {newState}");
        }

        public GroupsSidebarViewModel()
        {
            //_groups.Clear();
            if (Groups == null)
            {
                Groups = new ObservableCollection<BasicGroupInfo>();
                wsAPI.ConnectChangeEvent += ConnectChange;

                Groups.Add(new BasicGroupInfo() { Name = "Ceira", Id = "sdkfpasdkfasdf" });
                Groups.Add(new BasicGroupInfo() { Name = "Sinas", Id = "asdfjkaewqkjdw" });
                Groups.Add(new BasicGroupInfo() { Name = "Caldo de Pilha", Id = "sdfsodifjosidj" });
                Groups.Add(new BasicGroupInfo() { Name = "Sinas Express", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "Carreta Furacâo", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "Carreta Furacâo", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "Carreta Furacâo", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "Carreta Furacâo", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "Carreta Furacâo", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "Carreta Furacâo", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "Carreta Furacâo", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "Carreta Furacâo", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "Carreta Furacâo", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "Carreta Furacâo", Id = "sdfsjdfoisodif" });
                Groups.Add(new BasicGroupInfo() { Name = "Carreta Furacâo", Id = "sdfsjdfoisodif" });

                //wsAPI.client?.On("update_groups", Ws_OnUpdateGroups);
            }

        }
    }
}
