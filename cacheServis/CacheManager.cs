using System;
using System.Threading.Tasks;
using cacheServis.Settings;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace cacheServis
{
    public class CacheManager : ICacheService
    {
        private ConnectionMultiplexer _connectionMultiplexer;
        private CacheSettings _cacheSettings;
        public CacheManager( IOptions<CacheSettings> cacheSettings)
        {
            _cacheSettings = cacheSettings.Value;
        }
        

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect(_cacheSettings.Host+":"+_cacheSettings.Port);
        public IDatabase GetDb(int db) => _connectionMultiplexer.GetDatabase(db);
        

        public void CacheEkle(IDatabase db, string key, object value)
        {
            
            var jsonString = JsonConvert.SerializeObject(value);
            db.StringSet(key, jsonString,expiry:_cacheSettings.ExpiryTime);
        }

        public T CacheGetir<T>(IDatabase db, string key) where T : class
        {
            string objectString = db.StringGet(key);
            if (string.IsNullOrEmpty(objectString)) return null;
            else
            {
                T sonuc = JsonConvert.DeserializeObject<T>(objectString);
                return sonuc;
            }
        }
    }
}