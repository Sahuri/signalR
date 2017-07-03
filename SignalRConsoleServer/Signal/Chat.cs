using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRConsoleServer.Signal
{
    #region hub Chat
     [HubName("chatHub")]
    public class ChatHub : Hub
    {
        public void send(string message)
        {
            Clients.All.addMessage(message);
        }
    }
    #endregion
}
