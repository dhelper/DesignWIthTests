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

        public event EventHandler OnRing;

        public Phone(IPhoneClient client)
        {
            this._client = _client;
        }
    }

}
