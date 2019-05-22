using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLogic
{
    [ServiceContract]
    public interface IMyEchoService
    {
        [OperationContract(IsOneWay = true)]
        void EchoPlease(string s);
    }

    public class MyEchoService : IMyEchoService
    {
        public void EchoPlease(string s)
        {
            string res = $"{DateTime.Now.ToLongTimeString()} - {s}";
            Console.WriteLine(res);
        }
    }
}
