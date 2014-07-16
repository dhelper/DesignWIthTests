using System;

namespace PhoneCall.Core
{
    public class Phone2
    {
        public event EventHandler OnRing;

        private IPhoneClient _client;
        private StateBase _currentState;

        public Phone2(IPhoneClient client)
        {
            _client = client;
            _currentState = new IdleState(this);

            _client.OnPhoneRing += HandlePhoneRing;
            _client.OnConnectedToServer += HandleConnectedToServer;
        }

        public void AcceptCall()
        {
            _currentState.AcceptCall();
        }

        public void RejectCall()
        {
            _currentState.RejectCall();
        }

        internal void InvokePhoneRing(EventArgs eventArgs)
        {
            var handler = OnRing;

            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }

        private void HandleConnectedToServer(object sender, EventArgs e)
        {
            _currentState.HandleConnectedToServer();
        }

        private void HandlePhoneRing(object sender, EventArgs e)
        {
            _currentState.HandlePhoneRing();
        }


        internal void MoveToState(StateBase newState)
        {
            _currentState = newState;
        }

        internal void ConnectToServer()
        {
            _client.Connect();
        }
    }
}
