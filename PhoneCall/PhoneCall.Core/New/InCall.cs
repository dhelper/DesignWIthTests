using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneCall.Core.New
{
    class InCall : StateBase
    {
        private Phone2 _parent;

        public InCall(Phone2 _parent)
        {
            this._parent = _parent;
        }
    }
}
