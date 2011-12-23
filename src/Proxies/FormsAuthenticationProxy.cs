using System;
using System.Web.Security;

namespace MockableWebSecurity.Proxies
{
    public class FormsAuthenticationProxy: IFormsAuthentication
    {
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public void SetAuthCookie(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SetAuthCookie(string userName, bool createPersistentCookie, string cookiePath)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie, cookiePath);
        }
    }
}