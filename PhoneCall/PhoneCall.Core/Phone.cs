namespace PhoneCall.Core
{
    public class Phone
    {
        private readonly IPhoneClient _fakeClient;

        public Phone(IPhoneClient fakeClient)
        {
            _fakeClient = fakeClient;
        }
    }
}
