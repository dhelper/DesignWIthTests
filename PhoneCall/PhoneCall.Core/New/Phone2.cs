using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneCall.Core.New;

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

    abstract class StateBase
    {

        virtual public void AcceptCall() { }
       virtual public void RejectCall() { }

        virtual internal void HandleConnectedToServer()        {        }

        virtual internal void HandlePhoneRing()        {        }
    }

    class IdleState : StateBase
    {
        private Phone2 _parent;

        public IdleState(Phone2 parent)
        {
            _parent = parent;
        }

        internal override void HandlePhoneRing()
        {
            _parent.InvokePhoneRing(EventArgs.Empty);

            _parent.MoveToState(new PrepareCall(_parent));
        }
    }
}
