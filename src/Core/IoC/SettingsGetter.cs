namespace QuickOrder.Core.IoC
{
    public static class SettingsGetter
    {
        public static AppSettings Instance
        {
            get
            {
                return SettingsCacher.Get<AppSettings>();
            }
        }
    }

    public class SettingsCacher
    {
        private static readonly IDictionary<string, object> cache = new Dictionary<string, object>();

        public static T Add<T>(T data)
        {
            string fullName = typeof(T).FullName;
            if(!cache.ContainsKey(fullName))
            {
                cache[fullName] = data;
            }

            return (T)cache[fullName];
        }

        public static T Get<T>()
        {
            string fullName = typeof(T).FullName;
            if (cache.ContainsKey(fullName))
            {
                return (T)cache[fullName];
            }

            return default(T);
        }

        public static bool Remove<T>()
        {
            string fullName = typeof(T).FullName;
            if (cache.ContainsKey(fullName))
            {
                return cache.Remove(fullName);
            }

            return false;
        }
    }
}
