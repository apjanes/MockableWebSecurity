using System.Web.Security;

namespace MockableWebSecurity
{
    public interface IMembership
    {
        event MembershipValidatePasswordEventHandler ValidatingPassword;
        string ApplicationName { get; set; }
        bool EnablePasswordReset { get; }
        bool EnablePasswordRetrieval { get; }
        string HashAlgorithmType { get; }
        int MaxInvalidPasswordAttempts { get; }
        int MinRequiredNonAlphanumericCharacters { get; }
        int MinRequiredPasswordLength { get; }
        int PasswordAttemptWindow { get; }
        string PasswordStrengthRegularExpression { get; }
        IMembershipProvider Provider { get; }
        IMembershipProviderCollection Providers { get; }
        bool RequiresQuestionAndAnswer { get; }
        int UserIsOnlineTimeWindow { get; }

        IMembershipUser CreateUser(string username, string password);
        IMembershipUser CreateUser(string username, string password, string email);
        IMembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, out MembershipCreationStatus status);
        IMembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object provideUserKey, out MembershipCreationStatus status);
        bool DeleteUser(string username);
        bool DeleteUser(string username, bool deleteAllRelatedData);
        IMembershipUserCollection FindUsersByEmail(string emailToMatch);
        IMembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords);
        IMembershipUserCollection FindUsersByName(string usernameToMatch);
        IMembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords);
        string GeneratePassword(int length, int numberOfNonAlphaNumericCharacters);
        IMembershipUserCollection GetAllUsers();
        IMembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords);
        int GetNumberOfUsersOnline();
        IMembershipUser GetUser();
        IMembershipUser GetUser(object providerUserKey);
        IMembershipUser GetUser(bool userIsOnline);
        IMembershipUser GetUser(string username);
        IMembershipUser GetUser(string username, bool userIsOnline);
        string GetUserNameByEmail(string emailToMatch);
        void UpdateUser(IMembershipUser user);
        bool ValidateUser(string username, string password);
    }
}