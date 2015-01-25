using System;

namespace PhoneCall.Core
{
    public interface IPhoneClient
    {
        event EventHandler<EventArgs> OnPhoneRing;
        void Connect();
    }
}
