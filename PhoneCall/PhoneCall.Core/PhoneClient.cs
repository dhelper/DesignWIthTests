using System;

namespace PhoneCall.Core
{
    public interface IPhoneClient
    {
        event EventHandler<EventArgs> OnPhoneRing;
        event EventHandler<EventArgs> OnConnectedToServer;
        void Connect();
    }
}
