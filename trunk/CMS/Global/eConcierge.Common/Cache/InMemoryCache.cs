using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace eConcierge.Common.Cache
{
    public class InMemoryCache : ICacheService
    {
        private static ICacheService _cacheService;
        private ObjectCache _cache;
        static InMemoryCache()
        {
            _cacheService = new InMemoryCache();
        }
        private InMemoryCache()
        {
            _cache = MemoryCache.Default;
        }
        public T Get<T>(string cacheID, Func<T> getItemCallback) where T : class
        {
            T item = _cache.Get(cacheID) as T;
            if (item == null)
            {
                item = getItemCallback();
                var policy = new CacheItemPolicy();
                string expire = AppSettingHelper.GetValue(cacheID);
                if(string.IsNullOrEmpty(expire))
                {
                    expire = "9999";
                }
                policy.AbsoluteExpiration = DateTime.Now.AddMinutes(Convert.ToInt32(expire));
                _cache.Set(cacheID, item, policy);
            }
            return item;
        }
        

        public T2 Get<T1, T2>(string cacheID, Func<T1, T2> getItemCallback, T1 callBackParam)
            where T1 : class
            where T2 : class
        {
            var item = _cache.Get(cacheID) as T2;
            if (item == null)
            {
                item = getItemCallback(callBackParam);
                _cache[cacheID] = item;
            }
            return item;
        }

        public static ICacheService CacheService
        {
            get
            {
                return _cacheService;
            }
        }

    }

    public interface ICacheService
    {
        T Get<T>(string cacheID, Func<T> getItemCallback) where T : class;
        T2 Get<T1, T2>(string cacheID, Func<T1, T2> getItemCallback, T1 callBackParam)
            where T1 : class
            where T2 : class;
    }
}
