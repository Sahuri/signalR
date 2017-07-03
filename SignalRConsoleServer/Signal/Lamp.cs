using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Net;
using SignalRConsoleServer.Models;

namespace SignalRConsoleServer.Signal
{
    #region hub control lampu
    [HubName("lampHub")]
    public class LampHub : Hub
    {
        public void send(Message message)
        {

            var map = mapBtn(message);
            var url = Statics.url.arduino;
            var res = String.Format(@"{0}{1}", url, map);

            /*request to arduino*/
            try
            {
                var request = WebRequest.CreateHttp(res);
                {
                    /*return respon from server arduino*/
                    /*remark dulu belum ada servernya*/
                    WebResponse response = request.GetResponse();
                }
                Clients.All.addMessage(res);
            }
            catch(Exception ex) {
                var msg = "Not response from arduino : " + ex.Message;
                Clients.All.addMessage(msg);
            }

        }


        string mapBtn(Message message)
        {
            var param = "";
            foreach (Btn itm in message.arrbtn)
            {
                param = String.Format(@"{0}&{1}={2}", param, itm.btn, itm.status);
            }
            return param;
        }
    }
#endregion
}
