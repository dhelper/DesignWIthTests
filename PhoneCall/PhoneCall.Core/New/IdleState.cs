using System;
using PhoneCall.Core.New;

namespace PhoneCall.Core
{
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