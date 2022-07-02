using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace TaiyouClient
{
    public class GlobalState : ReactiveObject
    {
        private static GlobalState _singleton;
        public static GlobalState Instance
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new GlobalState();
                }

                return _singleton;
            }
        }

        #region ConnectedUser Properties
        string _connectedUser_Username = "@unnamed";
        public string ConnectedUser_Username
        {
            get => _connectedUser_Username;
            set => this.RaiseAndSetIfChanged(ref _connectedUser_Username, value);
        }

        bool _connectedUser_IsConnected = true;
        public bool ConnectedUser_IsConnected
        {
            get => _connectedUser_IsConnected;
            set => this.RaiseAndSetIfChanged(ref _connectedUser_IsConnected, value);
        }
        #endregion

        public GlobalState()
        {
            wsAPI.ConnectChangeEvent += WsAPI_ConnectChangeEvent;
        }

        private void WsAPI_ConnectChangeEvent(bool newState)
        {
            ConnectedUser_IsConnected = newState;
            ConnectedUser_Username = API.CurrentUser.Username;
        }

    }
}
