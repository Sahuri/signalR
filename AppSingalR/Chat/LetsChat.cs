using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net;


namespace AppSingalR
{
    #region hub Chat
    [HubName("myChatHub")]
        public class LetsChat : Hub
    {
        public void send(string message)
        {
            Clients.All.addMessage(message);
        }
    }
    #endregion

    #region hub control lampu
    [HubName("homeControlHub")]
    public class homeControl : Hub
    {
        public void send(Message message)
        {

            var map = mapBtn(message);
            var url = "http://192.168.20.48/?cmd=1";
            var res=String.Format(@"{0}{1}",url,map);
            
            /*request to arduino*/
            try
            {
                var request = WebRequest.CreateHttp(res);
                {

                    //WebRequest request = WebRequest.Create(res);
                    //request.Method = "GET";

                    /*return respon from server arduino*/
                    /*remark dulu belum ada servernya*/
                    WebResponse response = request.GetResponse();
                }
            }
            catch { }
            //Debug.WriteLine(((HttpWebResponse)response).StatusDescription);
            //Clients.All.addMessage(res, ((HttpWebResponse)response).StatusDescription);

           // Debug.WriteLine(res);
            //var msg = "belum ada servernya";
            Clients.All.addMessage(res);


        }


        string mapBtn(Message message)
        {
            var param="";
            foreach (Btn itm in message.arrbtn)
            {
                param=String.Format(@"{0}&{1}={2}",param,itm.btn,itm.status);
            }
            return param;
        }
    }

    #endregion

    #region class helper
    public class Message
    {

        [JsonProperty("connectionid")]
        public string connectionid
        {
            get;
            set;
        }

        [JsonProperty("arrbtn")]
        public List<Btn> arrbtn
        {
            get;
            set;
        }
    }

    public class Btn
    {
        [JsonProperty("status")]
        public string status
        {
            get;
            set;
        }
        [JsonProperty("btn")]
        public string btn
        {
            get;
            set;
        }

    }
    #endregion
}