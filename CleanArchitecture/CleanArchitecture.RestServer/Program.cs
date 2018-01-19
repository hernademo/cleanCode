using CleanArchitecture.RestServer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.RestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.Start();
            Console.WriteLine("Server started. Press any key to exit.");
            Console.ReadLine();
            Server.Stop();
        }
    }
}
