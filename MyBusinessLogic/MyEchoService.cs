using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLogic
{
    [ServiceContract]
    interface IMyEchoService
    {
        [OperationContract]
        string EchoPlease(string s);
    }

    public class MyEchoService : IMyEchoService
    {
        public string EchoPlease(string s)
        {
            string res = $"{DateTime.Now.ToShortTimeString()} - {s}";
            Console.WriteLine(res);
            return res;
        }
    }
}
