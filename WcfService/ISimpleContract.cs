using System;
using System.ServiceModel;

namespace EssentialWCF
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
