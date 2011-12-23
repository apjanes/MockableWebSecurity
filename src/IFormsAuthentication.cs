namespace MockableWebSecurity
{
    public interface IFormsAuthentication
    {
        void SetAuthCookie(string userName, bool createPersistentCookie);
        void SetAuthCookie(string userName, bool createPersistentCookie, string cookiePath);
        void SignOut();
    }
}