using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SignalRConsoleServer.Models
{
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
