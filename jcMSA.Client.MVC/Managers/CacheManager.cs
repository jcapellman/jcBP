using System;
using System.Web;
using System.Web.Caching;

using jcMSA.Client.MVC.Enums;
using jcMSA.Common.PCL.Transports.Container;

namespace jcMSA.Client.MVC.Managers {
    public static class CacheManager {        
        public static void Add<T>(CacheItems cacheItem, T value) { HttpContext.Current.Cache.Add(cacheItem.ToString(), value, null, DateTime.MaxValue, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, null); }

        public static bool CheckIfExists(CacheItems cacheItem) => HttpContext.Current.Cache[cacheItem.ToString()] != null;
        
        public static ReturnSet<T> Get<T>(CacheItems cacheItem) {
            return !CheckIfExists(cacheItem) ? new ReturnSet<T>(default(T), "No key exists in cache") : new ReturnSet<T>((T)HttpContext.Current.Cache[cacheItem.ToString()]);
        }
    }
}