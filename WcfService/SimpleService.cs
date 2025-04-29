using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace EssentialWCF
{
    public class SimpleService : ISimpleContract
    {
        public Task<DateTime> GetCurrentTimeAsync() =>
            Task.FromResult(DateTime.Now);

        public Task<string[]> GetFolderContentAsync(string path) =>
            Task.FromResult(System.IO.Directory.GetFiles(path));

        public Task<string> GetDayOfWeekAsync(DateTime date) =>
            Task.FromResult(date.DayOfWeek.ToString());

        public Task<int> AddAsync(int a, int b, string username)
        {
            if (username != "adder")
                throw new FaultException("Доступ запрещен: у вас нет прав на сложение.");
            return Task.FromResult(a + b);
        }

        public Task<int> SubtractAsync(int a, int b, string username)
        {
            if (username != "subtractor")
                throw new FaultException("Доступ запрещен: у вас нет прав на вычитание.");
            return Task.FromResult(a - b);
        }
    }
}
