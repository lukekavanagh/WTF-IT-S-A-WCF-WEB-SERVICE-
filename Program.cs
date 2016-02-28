using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace WcfService1
{
    public class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof (Service), new Uri("http://localhost:8000/"));
            try
            {
                ServiceEndpoint ep = host.AddServiceEndpoint(typeof (IService), new WebHttpBinding(), "");
                host.Open();
                using (ChannelFactory<IService> cf = new ChannelFactory<IService>(new WebHttpBinding(),
                    "http://localhost:8000"))
                {
                    cf.Endpoint.Behaviors.Add(new WebHttpBehavior());
                    IService channel = cf.CreateChannel();

                    string s;

                    Console.WriteLine("Ca..ing EchoWithGet via http GET");
                    s = channel.EchoWithGet("Hi,world!");
                    Console.WriteLine("Output {0}", s);
                    Console.WriteLine("");
                    Console.WriteLine("is can also be accomplished by navigating to");
                    Console.WriteLine("http://localhost:8000/EchoWithGet?s=Hi,world!");

                    Console.WriteLine("Calling EchoWithPost via HTTP POST: ");
                    s = channel.EchoWithPost("Hi,world!");
                    Console.WriteLine("   Output: {0}", s);
                    Console.WriteLine("");
                }

                Console.WriteLine("Press <ENTER> to terminate");
                Console.ReadLine();

                host.Close();
            }

            catch (CommunicationException cex)
            {

                Console.WriteLine("An exception occured {0}", cex.Message);
                host.Abort();
            }

        }
    }
}