using System;
using System.Web;
using System.Web.Caching;

using jcMSA.Common.PCL.Enums;
using jcMSA.Common.PCL.PlatformAbstractions;
using jcMSA.Common.PCL.Transports.Container;

namespace jcMSA.Client.MVC.PlatformImplementations {
    public class WebCachePI : IBaseCachePa {
        public ReturnSet<T> Get<T>(CacheItems cacheItem) {
            return !Exists(cacheItem) ? new ReturnSet<T>(default(T), "No key exists in cache") : new ReturnSet<T>((T)HttpContext.Current.Cache[cacheItem.ToString()]);
        }

        public void Add<T>(CacheItems cacheItem, T value) {
            HttpContext.Current.Cache.Add(cacheItem.ToString(), value, null, DateTime.MaxValue, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
        }

        public bool Exists(CacheItems cacheItem) => HttpContext.Current.Cache[cacheItem.ToString()] != null;
    }
}