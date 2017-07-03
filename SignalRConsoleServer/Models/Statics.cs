using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRConsoleServer.Models
{
    public class Statics
    {
        public struct url
        {
            public static readonly string arduino = ConfigurationManager.AppSettings["AddressArduino"];
            public static readonly string app = ConfigurationManager.AppSettings["ApplicationUrl"];
        }
    }
}
