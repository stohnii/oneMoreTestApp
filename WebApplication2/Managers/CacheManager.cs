using Microsoft.Extensions.Caching.Memory;
using System;

namespace WebApplication2.Managers
{
    public class CacheManager
    {
        private MemoryCache _cache;

        public CacheManager()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public T GetOrCreate<T>(string key, Func<ICacheEntry, T> func)
        {
            return _cache.GetOrCreate(key, func);
        }
    }
}
