using System.Web.Security;

namespace MockableWebSecurity.Proxies
{
    public class MembershipProviderProxy: ProxyBase<MembershipProvider>, IMembershipProvider
    {
        public MembershipProviderProxy(MembershipProvider instance) : base(instance)
        {
        }
    }
}