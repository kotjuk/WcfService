using System;
using System.ServiceModel;
using System.Threading.Tasks;
using EssentialWCF;

namespace EssentialWCFClient
{
    class Program
    {
        static async Task Main()
        {
            ChannelFactory<ISimpleContract> factory = new ChannelFactory<ISimpleContract>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:8000/WcfService")
            );

            ISimpleContract proxy = factory.CreateChannel();

            Console.WriteLine("дата (г-м-д):");
            string input = Console.ReadLine();

            if (DateTime.TryParse(input, out DateTime date))
            {
                string dayOfWeek = await proxy.GetDayOfWeekAsync(date);
                Console.WriteLine($"день недели: {dayOfWeek}");
            }
            else
            {
                Console.WriteLine("Ошибка: неверный формат даты.");
            }
        }
    }
}
