using System;

namespace PhoneCall.Core
{
    public class Phone
    {
        private readonly IPhoneClient _client;
        private bool _phoneAlreadyRang;

        public Phone(IPhoneClient client)
        {
            _client = client;
            _client.OnPhoneRing += HandlePhoneRing;
        }

        private void HandlePhoneRing(object sender, EventArgs e)
        {
            _phoneAlreadyRang = true;
        }

        public void AcceptCall()
        {
            if (_phoneAlreadyRang)
            {
                _client.Connect();
            }
        }

        public void RejectCall()
        {
            _phoneAlreadyRang = false;
        }
    }
}
