using System;
using System.Web.Security;

namespace MockableWebSecurity.Proxies
{
    public class MembershipProxy: IMembership
    {
        
        public event MembershipValidatePasswordEventHandler ValidatingPassword;

        public string ApplicationName
        {
            get { return Membership.ApplicationName; }
            set { Membership.ApplicationName = value; }
        }

        public bool EnablePasswordReset
        {
            get { return Membership.EnablePasswordReset; }
        }

        public bool EnablePasswordRetrieval
        {
            get { return Membership.EnablePasswordRetrieval; }
        }

        public string HashAlgorithmType
        {
            get { return Membership.HashAlgorithmType; }
        }

        public int MaxInvalidPasswordAttempts
        {
            get { return Membership.MaxInvalidPasswordAttempts; }
        }

        public int MinRequiredNonAlphanumericCharacters
        {
            get { return Membership.MinRequiredNonAlphanumericCharacters; }
        }

        public int MinRequiredPasswordLength
        {
            get { return Membership.MinRequiredPasswordLength; }
        }

        public int PasswordAttemptWindow
        {
            get { return Membership.PasswordAttemptWindow; }
        }

        public string PasswordStrengthRegularExpression
        {
            get { return Membership.PasswordStrengthRegularExpression; }
        }

        public IMembershipProvider Provider
        {
            get { return new MembershipProviderProxy(Membership.Provider); }
        }

        public IMembershipProviderCollection Providers
        {
            get { return new MembershipProviderCollectionProxy(Membership.Providers); }
        }

        public bool RequiresQuestionAndAnswer
        {
            get { return Membership.RequiresQuestionAndAnswer; }
        }

        public int UserIsOnlineTimeWindow
        {
            get { return Membership.UserIsOnlineTimeWindow; }
        }

        public IMembershipUser CreateUser(string username, string password)
        {
            return new MembershipUserProxy(Membership.CreateUser(username, password));
        }

        public IMembershipUser CreateUser(string username, string password, string email)
        {
            return new MembershipUserProxy(Membership.CreateUser(username, password, email));
        }

        public IMembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, out MembershipCreationStatus status)
        {
            MembershipCreateStatus mcs;
            var membershipUser = Membership.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, out mcs);
            status = (MembershipCreationStatus) Enum.Parse(typeof (MembershipCreationStatus), mcs.ToString());
            if (membershipUser == null) return null;
            var result = new MembershipUserProxy(membershipUser);
            return result;
        }

        public IMembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object provideUserKey, out MembershipCreationStatus status)
        {
            MembershipCreateStatus mcs;
            var membershipUser = Membership.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, provideUserKey, out mcs);
            status = (MembershipCreationStatus)Enum.Parse(typeof(MembershipCreationStatus), mcs.ToString());
            if (membershipUser == null) return null;
            var result = new MembershipUserProxy(membershipUser);
            return result;
        }

        public bool DeleteUser(string username)
        {
            return Membership.DeleteUser(username);
        }

        public bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            return Membership.DeleteUser(username, deleteAllRelatedData);
        }

        public IMembershipUserCollection FindUsersByEmail(string emailToMatch)
        {
            return new MembershipUserCollectionProxy(Membership.FindUsersByEmail(emailToMatch));
        }

        public IMembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return new MembershipUserCollectionProxy(Membership.FindUsersByEmail(emailToMatch, pageIndex, pageSize, out totalRecords));
        }

        public IMembershipUserCollection FindUsersByName(string usernameToMatch)
        {
            return new MembershipUserCollectionProxy(Membership.FindUsersByName(usernameToMatch));
        }

        public IMembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return new MembershipUserCollectionProxy(Membership.FindUsersByName(usernameToMatch, pageIndex, pageSize, out totalRecords));
        }

        public string GeneratePassword(int length, int numberOfNonAlphaNumericCharacters)
        {
            return Membership.GeneratePassword(length, numberOfNonAlphaNumericCharacters);
        }

        public IMembershipUserCollection GetAllUsers()
        {
            return new MembershipUserCollectionProxy(Membership.GetAllUsers());
        }

        public IMembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            return new MembershipUserCollectionProxy(Membership.GetAllUsers(pageIndex, pageSize, out totalRecords));
        }

        public int GetNumberOfUsersOnline()
        {
            return Membership.GetNumberOfUsersOnline();
        }

        public IMembershipUser GetUser()
        {
            return new MembershipUserProxy(Membership.GetUser());
        }

        public IMembershipUser GetUser(object providerUserKey)
        {
            return new MembershipUserProxy(Membership.GetUser(providerUserKey));
        }

        public IMembershipUser GetUser(bool userIsOnline)
        {
            return new MembershipUserProxy(Membership.GetUser(userIsOnline));
        }

        public IMembershipUser GetUser(string username)
        {
            return new MembershipUserProxy(Membership.GetUser(username));
        }

        public IMembershipUser GetUser(string username, bool userIsOnline)
        {
            return new MembershipUserProxy(Membership.GetUser(username, userIsOnline));
        }

        public string GetUserNameByEmail(string emailToMatch)
        {
            return Membership.GetUserNameByEmail(emailToMatch);
        }

        public void UpdateUser(IMembershipUser user)
        {
            Membership.UpdateUser(user.Instance);
        }

        public bool ValidateUser(string username, string password)
        {
            return Membership.ValidateUser(username, password);
        }
    }
}