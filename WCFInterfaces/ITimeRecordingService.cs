using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFInterfaces
{
  [ServiceContract(CallbackContract = typeof(ITimeRecordingClient))]
  public interface ITimeRecordingService
  {
    [OperationContract]
    void Login(string Username, string Password);

    [OperationContract]
    void Listen();

    [OperationContract]
    void StopListening();

   ApplicationUser GetUserCredentials
    {
      [OperationContract]
      get;
    }
  }
}
