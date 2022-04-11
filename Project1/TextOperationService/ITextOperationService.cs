using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TextOperationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITextOperationService" in both code and config file together.
    [ServiceContract]
    public interface ITextOperationService
    {
        [OperationContract]
        string DoWork(string text);
    }
}
