using MyBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost h = new ServiceHost(typeof(MyEchoService));
            h.Open();

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"MyEchoService is running and using the following endpoints");
            foreach(var e in h.Description.Endpoints)
            {
                Console.WriteLine($"Endpoint : {e.Address}");
            }
            Console.WriteLine("-------------------------------------------------------------");
            Console.Read();
        }
    }
}
