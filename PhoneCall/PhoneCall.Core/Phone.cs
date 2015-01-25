using System;

namespace PhoneCall.Core
{
    public class Phone
    {
        private readonly IPhoneClient _client;
        private bool _phoneAlreadyRang;
        private bool _callAccepted;

        public Phone(IPhoneClient client)
        {
            _client = client;
            _client.OnPhoneRing += HandlePhoneRing;
            _client.OnConnectedToServer += HandleConnectedToServer;
        }

        private void HandleConnectedToServer(object sender, EventArgs e)
        {
            if (_callAccepted)
            {
                _client.Connect();
            }
        }

        private void HandlePhoneRing(object sender, EventArgs e)
        {
            _phoneAlreadyRang = true;
        }

        public void AcceptCall()
        {
            if (_phoneAlreadyRang)
            {
                _callAccepted = true;
            }
        }

        public void RejectCall()
        {
            _phoneAlreadyRang = false;
        }
    }
}
