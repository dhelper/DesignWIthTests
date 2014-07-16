using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneCall.Core.New
{
    class PrepareCall : StateBase
    {
        private Phone2 _parent;

        public PrepareCall(Phone2 _parent)
        {
            this._parent = _parent;
        }

        public override void AcceptCall()
        {
            _parent.MoveToState(new WaitForMessage(_parent));
        }

        public override void RejectCall()
        {
            _parent.MoveToState(new IdleState(_parent));
        }

    }
}
