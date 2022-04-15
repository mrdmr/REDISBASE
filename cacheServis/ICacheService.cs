using cacheServis.Settings;
using StackExchange.Redis;

namespace cacheServis
{
    public interface ICacheService
    {
        public void Connect();
        public IDatabase GetDb(int dbNo);
        public void CacheEkle(IDatabase db, string key, object value);
        public T CacheGetir<T>(IDatabase db, string key) where T:class;
    }
}