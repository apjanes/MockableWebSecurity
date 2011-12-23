using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Security;

namespace MockableWebSecurity.Proxies
{
    public class MembershipUserCollectionProxy : ProxyBase<MembershipUserCollection>, IMembershipUserCollection
    {
        private readonly List<IMembershipUser> _castList;
        private bool _isReadOnly;
        private object _lockObj = new object();

        public MembershipUserCollectionProxy(MembershipUserCollection instance) :
            base(instance)
        {
            _castList = new List<IMembershipUser>();
            Sync();
            var type = instance.GetType();
            var propInfo = type.GetField("_ReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            if(propInfo != null) _isReadOnly = (bool)propInfo.GetValue(instance);
        }

        public IMembershipUser this[string name]
        {
            get
            {
                return _castList.FirstOrDefault(x => x.UserName.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        public int Count
        {
            get { return Instance.Count; }
        }

        public bool IsReadOnly
        {
            get { return _isReadOnly; }
        }

        public void Add(IMembershipUser user)
        {
            lock(_lockObj)
            {
                Instance.Add(user.Instance);
                _castList.Add(user);    
            }
            
        }

        public void Clear()
        {
            Instance.Clear();
            _castList.Clear();
        }

        public bool Contains(IMembershipUser item)
        {
            if(item != null)
            {
                return this[item.UserName] != null;
            }

            return false;
        }

        public void CopyTo(IMembershipUser[] array, int index)
        {
            _castList.CopyTo(array, index);
        }

        IEnumerator<IMembershipUser> IEnumerable<IMembershipUser>.GetEnumerator()
        {
            return _castList.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return _castList.GetEnumerator();
        }

        public void Remove(string name)
        {
            lock (_lockObj)
            {
                var instance = _castList.FirstOrDefault(x => String.Equals(x.UserName, name, StringComparison.CurrentCultureIgnoreCase));
                Instance.Remove(name);
                if (instance != null) _castList.Remove(instance);
            }
        }

        public bool Remove(IMembershipUser item)
        {
            if(item != null)
            {
                lock (_lockObj)
                {
                    Remove(item.UserName);
                    var instance =
                        _castList.FirstOrDefault(
                            x => String.Equals(x.UserName, item.UserName, StringComparison.CurrentCultureIgnoreCase));
                    if (instance != null)
                    {
                        _castList.Remove(instance);
                        return true;
                    }
                }
            }
            return false;
        }

        public void SetReadOnly()
        {
            Instance.SetReadOnly();
            _isReadOnly = true;
        }
        
        private void Sync()
        {
            if(Instance != null && Instance.Count != _castList.Count)
            {
                _castList.Clear();
                foreach (var item in Instance)
                {
                    _castList.Add(new MembershipUserProxy((MembershipUser)item));
                }
            }
        }
    }
}