using System;

namespace cacheServis.Settings
{
    public class CacheSettings
    {
        public enum DatabaseName
        {
            Iq = 1,
            Online = 2,
            TemizMama = 3,
        }

        public string Host { get; set; }
        public string Port { get; set; }
        public string AccessKey { get; set; }
        public bool Ssl { get; set; }
        public TimeSpan ExpiryTime { get; set; }

    }
}