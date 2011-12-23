using System.Web.Security;

namespace MockableWebSecurity.Proxies
{
    public class MembershipProviderCollectionProxy: ProxyBase<MembershipProviderCollection>, IMembershipProviderCollection
    {
        public MembershipProviderCollectionProxy(MembershipProviderCollection instance) : base(instance)
        {
        }
    }
}