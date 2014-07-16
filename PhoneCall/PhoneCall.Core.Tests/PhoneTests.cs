using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Phone = PhoneCall.Core.Phone2;

namespace PhoneCall.Core.Tests
{
    [TestFixture]
    public class PhoneTests
    {
        [Test]
        public void OnPhoneRings_PhoneRingsMessageRecieved_PhoneRingEventRaised()
        {
            var fakeClient = A.Fake<IPhoneClient>();

            var wasCalled = false;

            var phone = new Phone(fakeClient);
            phone.OnRing += (o, e) => wasCalled = true;

            fakeClient.OnPhoneRing += Raise.WithEmpty().Now;

            Assert.That(wasCalled, Is.True);
        }

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
            var numberTimeCalled =  0;
            phone.OnRing += (o, e) => numberTimeCalled++;

            fakeClient.OnPhoneRing += Raise.WithEmpty().Now;

            phone.RejectCall();

             fakeClient.OnPhoneRing += Raise.WithEmpty().Now;

            Assert.That(numberTimeCalled, Is.EqualTo(2));
        }

        [Test]
        public void OnPhoneRings_CalledTwice_OnlyRaiseOneEvent()
        {
            var fakeClient = A.Fake<IPhoneClient>();

            var phone = new Phone(fakeClient);
            var numberTimeCalled = 0;
            phone.OnRing += (o, e) => numberTimeCalled++;

            fakeClient.OnPhoneRing += Raise.WithEmpty().Now;
            fakeClient.OnPhoneRing += Raise.WithEmpty().Now;

            Assert.That(numberTimeCalled, Is.EqualTo(1));
        }
    }
}
