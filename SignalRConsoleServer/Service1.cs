using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using Owin;
using SignalRConsoleServer.Models;
using SignalRConsoleServer.Signal;

[assembly: OwinStartup(typeof(SignalRConsoleServer.Startup))] 
namespace SignalRConsoleServer
{
    partial class Service1 : ServiceBase
    {
        string url = "";
        private IDisposable SignalR;
        public Service1()
        {
            url = Statics.url.app;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            SignalR = WebApp.Start(url); 
        }

        protected override void OnStop()
        {
            SignalR.Dispose();
            
        }

#if DEBUG
        public static void Main(String[] args)
        {
            var svc = new Service1();
            try
            {
                svc.OnStart(new string[1]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("===================================================================");
                Console.WriteLine(string.Format("{0} is running under debug mode url:{1}", svc.ServiceName, svc.url));
                Console.WriteLine("===================================================================");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                 P r e s s   A n y   K e y ! ! ! !     ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("===================================================================");
                Console.ReadLine();
                svc.OnStop();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("===================================================================");
                Console.WriteLine(string.Format("{0} is not running under debug mode url:{1}", svc.ServiceName, svc.url));
                Console.WriteLine("===================================================================");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Message = " + ex.Message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("===================================================================");
                Console.ReadLine();
            }
        }
#endif

    }
    public class Startup
    {

        //config WebAPI
        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            return config;
        }

        //config timer
        void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<WeatherHub>();

            var resultUno ="{\"Status\":\"OK\",\"Data\":[{\"Key\":\"Humidity\",\"Value\":65.00},{\"Key\":\"CTemperature\",\"Value\":27.00},{\"Key\":\"FTemperature\",\"Value\":80.60},{\"Key\":\"CHeadIndex\",\"Value\":28.45}]}";

            context.Clients.All.readSensor(resultUno);
        }


        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = ConfigureWebApi();

            var aTimer = new System.Timers.Timer();

            aTimer.Elapsed += aTimer_Elapsed;
            aTimer.Interval = 5000;
            aTimer.Enabled = true;

            app.UseWebApi(webApiConfiguration);

            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                };

                hubConfiguration.EnableDetailedErrors = true;
                map.RunSignalR(hubConfiguration);
            });

            
        }
    }
}
