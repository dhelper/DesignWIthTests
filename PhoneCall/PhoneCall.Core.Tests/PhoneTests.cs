using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void OnPhoneRings_PhoneRingsMessageAndUserAcceptsCall_ConnectToServer()
        {
            var fakeClient = A.Fake<IPhoneClient>();

            var phone = new Phone(fakeClient);
           
            fakeClient.OnPhoneRing += Raise.WithEmpty().Now;

            phone.AcceptCall();

            A.CallTo(() => fakeClient.Connect()).MustHaveHappened();
        }

        [Test]
        public void AcceptCall_WithoutPhoneRing_DoNotConnectToServer()
        {
            var fakeClient = A.Fake<IPhoneClient>();

            var phone = new Phone(fakeClient);

            phone.AcceptCall();

            A.CallTo(() => fakeClient.Connect()).MustNotHaveHappened();
        }
    }
}
