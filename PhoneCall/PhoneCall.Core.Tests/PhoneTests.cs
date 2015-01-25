using FakeItEasy;
using NUnit.Framework;

namespace PhoneCall.Core.Tests
{
    [TestFixture]
    public class PhoneTests
    {
        [Test]
        public void OnPhoneRings_PhoneRingsMessageAndUserAcceptsCallThenRecieveMessageFromCaller_ConnectToServer()
        {
            var fakeClient = A.Fake<IPhoneClient>();

            var phone = new Phone(fakeClient);

            fakeClient.OnPhoneRing += Raise.WithEmpty().Now;

            phone.AcceptCall();

            A.CallTo(() => fakeClient.Connect()).MustHaveHappened();
        }
     
    }
}
