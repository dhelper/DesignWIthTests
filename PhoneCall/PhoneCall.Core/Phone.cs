namespace PhoneCall.Core
{
    public class Phone
    {
        private readonly IPhoneClient _client;

        public Phone(IPhoneClient client)
        {
            _client = client;
        }
    }
}
