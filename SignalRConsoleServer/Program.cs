using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SignalRConsoleServer
{
public class Program
{
#if (DEBUG != true)
       static void Main(string[] args)
        {
            var ServicesToRun = new ServiceBase[] { new Service1() };
            ServiceBase.Run(ServicesToRun);
        }
#endif
    }
}
