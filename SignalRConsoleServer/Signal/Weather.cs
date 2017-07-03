using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRConsoleServer.Signal
{
    #region hub sensor suhu
     [HubName("weatherHub")]
    public class WeatherHub : Hub
    {
         public void readSensor(string message)
         {
             Clients.All.readSensor(message);
         }
    }
    #endregion
}
