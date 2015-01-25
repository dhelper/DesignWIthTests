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

            fakeClient.OnConnectedToServer += Raise.WithEmpty().Now;

            A.CallTo(() => fakeClient.Connect()).MustHaveHappened();
        }

        [Test]
        public void OnPhoneRings_PhoneRingsMessageAndUserAcceptsCall_DoNotConnectToServer()
        {
            var fakeClient = A.Fake<IPhoneClient>();

            var phone = new Phone(fakeClient);

            fakeClient.OnPhoneRing += Raise.WithEmpty().Now;

            phone.AcceptCall();

            A.CallTo(() => fakeClient.Connect()).MustNotHaveHappened();
        }

        [Test]
        public void AcceptCall_WithoutPhoneRing_DoNotConnectToServer()
        {
            var fakeClient = A.Fake<IPhoneClient>();

            var phone = new Phone(fakeClient);

            phone.AcceptCall();

            A.CallTo(() => fakeClient.Connect()).MustNotHaveHappened();
        }

        [Test]
        public void OnPhoneRings_PhoneRingsMessageAndUserRejectCall_EndCall()
        {
            var fakeClient = A.Fake<IPhoneClient>();

            var phone = new Phone(fakeClient);

            fakeClient.OnPhoneRing += Raise.WithEmpty().Now;

            phone.RejectCall();
            phone.AcceptCall();

            A.CallTo(() => fakeClient.Connect()).MustNotHaveHappened();
        }
    }
}
