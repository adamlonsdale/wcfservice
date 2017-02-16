using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFInterfaces
{
  public interface ITimeRecordingClient
  {
    [OperationContract(IsOneWay = true)]
    void ReceiveMessage(string userName, string message);
  }
}
