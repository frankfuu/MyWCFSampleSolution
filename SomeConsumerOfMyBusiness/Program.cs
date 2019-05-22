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
            ChannelFactory<IMyEchoService> channelFactory = null;

            string[] validTransportSelections = new string[] { "1", "2", "3" };

            Console.WriteLine($"Please choose mode Transport");
            Console.WriteLine($"1) HTTP ");
            Console.WriteLine($"2) TCP ");
            Console.WriteLine($"3) MSMQ ");

            string selectedTransport = null;
            bool validTransportOptionSelected = false;

            while (!validTransportOptionSelected)
            {
                selectedTransport = Console.ReadLine();
                validTransportOptionSelected = !(selectedTransport == null || selectedTransport == "" || !validTransportSelections.Contains(selectedTransport));
            }

            if (selectedTransport == "1")
                channelFactory = GetHttpChannelFactory<IMyEchoService>("http://localhost:8880/MyEchoService");
            if (selectedTransport == "2")
                channelFactory = GetNetTCPChannelFactory<IMyEchoService>("net.tcp://localhost:8881/MyEchoService");
            if (selectedTransport == "3")
                 channelFactory = GetMSMQChannelFactory<IMyEchoService>("net.msmq://localhost/private/MyEchoService");

            var channel = channelFactory.CreateChannel();


           Console.WriteLine($"Type a message and it will be sent to {channelFactory.Endpoint.Address}");
            while(true)
            {
                var input = Console.ReadLine();
                if (input == "q")
                    break;

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

        private static ChannelFactory<T> GetMSMQChannelFactory<T>(string endPointAddress)
        {
            var binding = new NetMsmqBinding(securityMode: NetMsmqSecurityMode.None) { ExactlyOnce = false }; // Needs to match exactly with the Service Host!
            var channelFactory = new ChannelFactory<T>(binding, endPointAddress);

            return channelFactory;
        }
    }
}
