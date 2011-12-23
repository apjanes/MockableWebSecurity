namespace MockableWebSecurity.Proxies
{
    public class ProxyBase<T>
    {
        public ProxyBase(T instance)
        {
            Instance = instance;
        }

        public T Instance { get; private set; }
    }
}