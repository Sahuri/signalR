using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using SignalRConsoleServer.Signal;

namespace SignalRConsoleServer.Controller
{
    public class SensorSuhuController : ApiController
    {
   
        // POST api/<controller>
        [HttpPost]
        public void SendSensor(string value)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<WeatherHub>();
            context.Clients.All.readSensor(value);
            //return value;
        }

    
    }
}