using System;
using System.Web.Security;
using FluentAssertions;
using MockableWebSecurity.Proxies;
using NUnit.Framework;

namespace MockableWebSecurity.UnitTests.Proxies
{
    [TestFixture]
    public class MembershipUserProxyFixture
    {
        private MembershipUser _src;
        private MembershipUserProxy _proxy;

        [SetUp]
        public void SetUp()
        {
            _src = CreateUser("apjanes", true);
            _proxy = new MembershipUserProxy(_src);
        }

        [Test]
        public void CommentShouldMatchSource()
        {
            _proxy.Comment.Should().Be(_proxy.Comment);
        }

        [Test]
        public void CreationDateShouldMatchSource()
        {
            _proxy.CreationDate.Should().Be(_proxy.CreationDate);
        }

        [Test]
        public void EmailShouldMatchSource()
        {
            _proxy.Email.Should().Be(_proxy.Email);
        }

        [Test]
        public void IsApprovedShouldMatchSource()
        {
            _proxy.IsApproved.Should().Be(_proxy.IsApproved);
        }

        [Test]
        public void IsLockedOutShouldMatchSource()
        {
            _proxy.IsLockedOut.Should().Be(_proxy.IsLockedOut);
        }

        [Test]
        public void IsOnlineShouldMatchSource()
        {
            _proxy.IsOnline.Should().Be(_proxy.IsOnline);
        }

        [Test]
        public void LastActivityDateShouldMatchSource()
        {
            _proxy.LastActivityDate.Should().Be(_proxy.LastActivityDate);
        }

        [Test]
        public void LastLockoutDateDateShouldMatchSource()
        {
            _proxy.LastLockoutDate.Should().Be(_proxy.LastLockoutDate);
        }

        [Test]
        public void LastLoginDateDateDateShouldMatchSource()
        {
            _proxy.LastLoginDate.Should().Be(_proxy.LastLoginDate);
        }

        [Test]
        public void UserNameShouldBeSource()
        {
            _proxy.UserName.Should().Be(_proxy.UserName);
        }

        public static MembershipUser CreateUser(string username, bool isLockedOut = false)
        {
            var user = new MembershipUser("AspNetSqlMembershipProvider", username, "apjanes", "apjanes@gmail.com",
                                          "a question", "comment", true, isLockedOut, DateTime.Now, DateTime.Now, DateTime.Now,
                                          DateTime.Now, DateTime.Now);
            return user;
        }

        public static IMembershipUser CreateProxyUser(string username)
        {
            return new MembershipUserProxy(CreateUser(username));
        } 
    }
}