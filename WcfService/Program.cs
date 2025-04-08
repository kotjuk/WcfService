using System;
using System.ServiceModel;

namespace EssentialWCF
{
    class Program
    {
        static void Main()
        {
            Uri baseAddress = new Uri("http://localhost:8000/WcfService");

            using (ServiceHost host = new ServiceHost(typeof(SimpleService), baseAddress))
            {
                host.AddServiceEndpoint(typeof(ISimpleContract), new BasicHttpBinding(), "");

                host.Open();
                Console.WriteLine("WCF-сервис запущен по адресу: " + baseAddress);
                Console.ReadLine();

                host.Close();
            }
        }
    }
}