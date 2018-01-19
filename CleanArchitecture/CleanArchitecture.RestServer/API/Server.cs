using CleanArchitecture.Infraestructure.CrossCutting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace CleanArchitecture.RestServer.API
{
    public class Server
    {
        private static ConcurrentQueue<Task> TaskQueue = new ConcurrentQueue<Task>();
        private static HttpSelfHostServer server;
        private static bool running;

        public static string Host
        {
            get
            {
                return ConfigurationManager.AppSettings["host"];
            }
        }

        public static bool Running
        {
            get
            {
                return running;
            }
        }

        public static void Stop()
        {
            throw new NotImplementedException();
        }

        public static void Start()
        {
            var config = new HttpSelfHostConfiguration(Host);

            config.Formatters.Clear();
            // config.Formatters.Add(new BsonMediaTypeFormatter());
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings =
            new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            config.DependencyResolver = IoCHelper.GetDependencyResolver();

            server = new HttpSelfHostServer(config);

            running = true;

            server.OpenAsync().Wait();

            Console.WriteLine($"Server running on {Host}");
        }
    }
}
