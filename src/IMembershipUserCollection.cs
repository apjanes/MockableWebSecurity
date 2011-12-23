using System.Collections;
using System.Collections.Generic;

namespace MockableWebSecurity
{
    public interface IMembershipUserCollection : ICollection<IMembershipUser>
    {
        void Remove(string name);

        void SetReadOnly();
    }
}