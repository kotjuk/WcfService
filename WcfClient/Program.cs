using System;
using System.ServiceModel;

namespace EssentialWCFClient
{
    class Program
    {
        static void Main()
        {
            ChannelFactory<ISimpleContract> factory = new ChannelFactory<ISimpleContract>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:8000/WcfService"));

            ISimpleContract proxy = factory.CreateChannel();

            DateTime serverTime = proxy.GetCurrentTime();
            Console.WriteLine($"время на сервере: {serverTime}");

            string folderPath = @"C:\Users\kolja\source\repos\WcfService\WcfService";
            string[] files = proxy.GetFolderContent(folderPath);

            Console.WriteLine("файлы в папке:");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            Console.ReadKey();
        }
    }
}
