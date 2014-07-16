using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneCall.Core.New
{
    class WaitForMessage : StateBase
    {
        private Phone2 _parent;

        public WaitForMessage(Phone2 _parent)
        {
            this._parent = _parent;
        }

        internal override void HandleConnectedToServer()
        {
            _parent.ConnectToServer();
            _parent.MoveToState(new InCall(_parent));
        }
    }
}
