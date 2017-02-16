using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFInterfaces;

namespace WCFService
{
  [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
  public class TimeRecordingServiceImpl : ITimeRecordingService
  {
    private ApplicationUser _user;
    private List<ITimeRecordingClient> _lstCons = new List<ITimeRecordingClient>();
    public void Login(string Username, string Password)
    {
      var user = new ApplicationUser { Username = Username, Password = Password };
      _user = user;

      foreach (ITimeRecordingClient con in _lstCons)
        con.ReceiveMessage(Username, Password);
    }

    public void Listen()
    {
      var connection = OperationContext.Current.GetCallbackChannel<ITimeRecordingClient>();
      _lstCons.Add(connection);
    }

    public void StopListening()
    {
      var con = OperationContext.Current.GetCallbackChannel<ITimeRecordingClient>();
      _lstCons.Remove(con);
    }

    public ApplicationUser GetUserCredentials
    {
      get
      {
        return _user;
      }
    }
  }
}