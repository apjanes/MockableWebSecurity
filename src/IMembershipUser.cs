using System;
using System.Web.Security;

namespace MockableWebSecurity
{
    public interface IMembershipUser
    {
        MembershipUser Instance { get; }

        string Comment { get; set; }
        DateTime CreationDate { get; }
        string Email { get; set; }
        string UserName { get; }
        bool IsApproved { get; set; }
        bool IsLockedOut { get; }
        bool IsOnline { get; }
        DateTime LastActivityDate { get; set; }
        DateTime LastLockoutDate { get; }
        DateTime LastLoginDate { get; set; }
        DateTime LastPasswordChangeDate { get; }
        string PaswordQuestion { get; }
        string ProviderName { get; }
        object ProviderUserKey { get; }

        bool ChangePassword(string oldPassword, string newPassword);
        bool ChangePasswordQuestionAndAnswer(string password, string newPasswordQuestion, string newPasswordAnswer);
        string GetPassword();
        string GetPassword(string passwordAnswer);
        string ResetPassword();
        string ResetPassword(string passwordAnswer);
        bool UnlockUser();
    }
}