using System;
using System.ServiceModel;

namespace EssentialWCFClient
{
    [ServiceContract]
    public interface ISimpleContract
    {
        [OperationContract]
        DateTime GetCurrentTime();

        [OperationContract]
        string[] GetFolderContent(string path);
    }
}
