namespace PhoneCall.Core
{
    abstract class StateBase
    {

        virtual public void AcceptCall() { }
        virtual public void RejectCall() { }

        virtual internal void HandleConnectedToServer()        {        }

        virtual internal void HandlePhoneRing()        {        }
    }
}