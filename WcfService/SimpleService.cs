using System;
using System.IO;
using System.ServiceModel;
using System.Threading.Tasks;

namespace EssentialWCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class SimpleService : ISimpleContract
    {
        private readonly DateTime _instanceTime;

        public SimpleService()
        {
            _instanceTime = DateTime.Now; 
        }

        public async Task<DateTime> GetCurrentTimeAsync()
        {
            await Task.Delay(100); 
            return _instanceTime; 
        }

        public async Task<string[]> GetFolderContentAsync(string path)
        {
            return await Task.Run(() => Directory.GetFiles(path)); 
        }

        public async Task<string> GetDayOfWeekAsync(DateTime date)
        {
            return await Task.Run(() => date.DayOfWeek.ToString());
        }
    }
}
