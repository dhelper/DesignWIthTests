using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCall.Core
{
    public class Phone
    {
        private IPhoneClient _client;
        private bool _phoneAlreadyRang;
        private bool _callAccepted;

        public event EventHandler OnRing;

        public Phone(IPhoneClient client)
        {
            this._client = client;

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
            if (_phoneAlreadyRang == false)
            {
                _phoneAlreadyRang = true;

                InvokePhoneRing(e);
            }
        }

        public void InvokePhoneRing(EventArgs eventArgs)
        {
            var handler = OnRing;

            if (handler != null)
            {
                handler(this, eventArgs);
            }
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
