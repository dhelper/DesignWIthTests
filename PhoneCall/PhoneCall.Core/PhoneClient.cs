using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCall.Core
{
    public interface IPhoneClient
    {
        event EventHandler OnPhoneRing;
        event EventHandler OnConnectedToServer;

        object Connect();
    }
}
