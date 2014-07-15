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

            Assert.That(fakeClient, Is.True);
        }
    }
}
