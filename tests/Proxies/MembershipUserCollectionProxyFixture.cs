using System;
using System.Web.Security;
using FluentAssertions;
using MockableWebSecurity.Proxies;
using NUnit.Framework;

namespace MockableWebSecurity.UnitTests.Proxies
{
    [TestFixture]
    public class MembershipUserCollectionProxyFixture
    {
        private MembershipUserCollection _src;
        private MembershipUserCollectionProxy _proxy;

        [SetUp]
        public void SetUp()
        {
            _src = new MembershipUserCollection { MembershipUserProxyFixture.CreateUser("apjanes"), MembershipUserProxyFixture.CreateUser("cljanes") };
            _proxy = new MembershipUserCollectionProxy(_src);
        }

        [Test]
        public void AddShouldAddToProxyAndSource()
        {
            _proxy.Add(MembershipUserProxyFixture.CreateProxyUser("abjanes"));
            _src["abjanes"].Should().NotBeNull();
        }

        [Test]
        public void ConstructorShouldFillProxyFromSource()
        {
            _proxy.Count.Should().Be(_src.Count);
            _proxy["apjanes"].UserName.Should().Be(_src["apjanes"].UserName);

        }

        [Test]
        public void ConstructorShouldCreateEmptyProxyForEmptySource()
        {
            var proxy = new MembershipUserCollectionProxy(new MembershipUserCollection());
            proxy.Should().BeEmpty();
        }

        [Test]
        public void RemoveShouldRemoveFromBothSourceAndProxyWhenUsingString()
        {
            _proxy.Remove("apjanes");
            _proxy["apjanes"].Should().BeNull();
            _src["apjanes"].Should().BeNull();
        }

        [Test]
        public void RemoveShouldRemoveFromBothSourceAndProxyWhenUsingUser()
        {
            var user = _proxy["apjanes"];
            _proxy.Remove(user);
            _proxy["apjanes"].Should().BeNull();
            _src["apjanes"].Should().BeNull();
        }
    }
}