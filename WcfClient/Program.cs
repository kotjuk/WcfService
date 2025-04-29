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

            Console.Write("Введите имя пользователя (adder или subtractor): ");
            string username = Console.ReadLine();

            Console.Write("Введите первое число: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите второе число: ");
            int b = int.Parse(Console.ReadLine());

            try
            {
                if (username == "adder")
                {
                    int result = await proxy.AddAsync(a, b, username);
                    Console.WriteLine($"Результат сложения: {result}");
                }
                else if (username == "subtractor")
                {
                    int result = await proxy.SubtractAsync(a, b, username);
                    Console.WriteLine($"Результат вычитания: {result}");
                }
                else
                {
                    Console.WriteLine("Неизвестный пользователь.");
                }
            }
            catch (FaultException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}
