using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLogic
{
    interface IMyEchoService
    {
        string EchoPlease(string s);
    }

    class MyEchoService : IMyEchoService
    {
        public string EchoPlease(string s)
        {
            string res = $"{DateTime.Now.ToShortTimeString()} - {s}";
            Console.WriteLine(res);
            return res;
        }
    }
}
