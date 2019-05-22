using MyBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace SomeConsumerOfMyBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            //var channelFactory = GetHttpChannelFactory<IMyEchoService>("http://localhost:8880/MyEchoService");
            var channelFactory = GetNetTCPChannelFactory<IMyEchoService>("net.tcp://localhost:8881/MyEchoService");
            var channel = channelFactory.CreateChannel();

            Console.WriteLine($"Type a message and it will be sent to {channelFactory.Endpoint.Address}");
            while(true)
            {
                var input = Console.ReadLine();
                if(input != "q")
                    channel.EchoPlease(input);
            }
        }

        private static ChannelFactory<T> GetHttpChannelFactory<T>(string endPointAddress)
        {
            var binding = new BasicHttpBinding();
            var channelFactory = new ChannelFactory<T>(binding, endPointAddress);

            return channelFactory;
        }

        private static ChannelFactory<T> GetNetTCPChannelFactory<T>(string endPointAddress)
        {
            var binding = new NetTcpBinding();
            var channelFactory = new ChannelFactory<T>(binding, endPointAddress);

            return channelFactory;
        }
    }
}
