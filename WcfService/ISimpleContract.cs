using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace EssentialWCF
{
    [ServiceContract]
    public interface ISimpleContract
    {
        [OperationContract]
        Task<DateTime> GetCurrentTimeAsync();

        [OperationContract]
        Task<string[]> GetFolderContentAsync(string path);

        [OperationContract]
        Task<string> GetDayOfWeekAsync(DateTime date);
    }
}
