using System;
using System.Web.Security;

namespace MockableWebSecurity.Proxies
{
    public class MembershipUserProxy: ProxyBase<MembershipUser>, IMembershipUser
    {
        public MembershipUserProxy(MembershipUser user): base(user)
        {
        }

        public string Comment
        {
            get { return Instance.Comment; }
            set { Instance.Comment = value; }
        }

        public DateTime CreationDate
        {
            get { return Instance.CreationDate; }
        }

        public string Email
        {
            get { return Instance.Email; }
            set { Instance.Email = value; }
        }

        public bool IsApproved
        {
            get { return Instance.IsApproved; }
            set { Instance.IsApproved = value; }
        }

        public bool IsLockedOut
        {
            get { return Instance.IsLockedOut; }
        }

        public bool IsOnline
        {
            get { return Instance.IsOnline; }
        }

        public DateTime LastActivityDate
        {
            get { return Instance.LastActivityDate; }
            set { Instance.LastActivityDate = value; }
        }

        public string UserName
        {
            get { return Instance.UserName; }
        }

        public DateTime LastLockoutDate
        {
            get { return Instance.LastLockoutDate; }
        }

        public DateTime LastLoginDate
        {
            get { return Instance.LastLoginDate; }
            set { LastLoginDate = value; }
        }

        public DateTime LastPasswordChangeDate
        {
            get { return Instance.LastPasswordChangedDate; }
        }

        public string PaswordQuestion
        {
            get { return Instance.PasswordQuestion; }
        }

        public string ProviderName
        {
            get { return Instance.ProviderName; }
        }

        public object ProviderUserKey
        {
            get { return Instance.ProviderUserKey; }
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            return Instance.ChangePassword(oldPassword, newPassword);
        }

        public bool ChangePasswordQuestionAndAnswer(string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            return Instance.ChangePasswordQuestionAndAnswer(password, newPasswordQuestion, newPasswordAnswer);
        }

        public string GetPassword()
        {
            return Instance.GetPassword();
        }

        public string GetPassword(string passwordAnswer)
        {
            return Instance.GetPassword(passwordAnswer);
        }

        public string ResetPassword()
        {
            return Instance.ResetPassword();
        }

        public string ResetPassword(string passwordAnswer)
        {
            return Instance.ResetPassword(passwordAnswer);
        }

        public override string ToString()
        {
            return Instance.ToString();
        }

        public bool UnlockUser()
        {
            return Instance.UnlockUser();
        }
    }
}