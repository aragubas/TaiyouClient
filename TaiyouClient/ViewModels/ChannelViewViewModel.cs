using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using TaiyouClient.Models;

namespace TaiyouClient.ViewModels
{
    public class ChannelViewViewModel : ViewModelBase
    {
        BasicChannelInfo _info = new BasicChannelInfo() {  Id="1234567890abcdef", Name= "Channel" };
        public BasicChannelInfo Info
        {
            get => _info;
            set => this.RaiseAndSetIfChanged(ref _info, value);
        }

        string _ceira = "unchanged_name";
        public string Ceira
        {
            get => _ceira;
            set => this.RaiseAndSetIfChanged(ref _ceira, value);
        }

        bool _isLoading = true;
        public bool IsLoading
        {
            get => _isLoading;
            set => this.RaiseAndSetIfChanged(ref _isLoading, value);
        }

        public void LoadChannel(BasicChannelInfo channel)
        {
            Info = channel;
            Console.WriteLine($"Channel: {channel.Name}");
            Console.WriteLine($"    Id:{channel.Id}");
        }
    }
}
