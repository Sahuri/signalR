using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRConsoleServer.Models
{
    public class ResponseUno
    {
        public string Status { get; set; }
        public List<DataUno> Result
        {
            get;
            set;
        }
    }

    public class DataUno
    {
        public string Key { get; set; }
        public float value { get; set; }

    }
}
