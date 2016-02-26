using System;
using System.Web;
using System.Web.Caching;

using jcMSA.Common.PCL.Enums;
using jcMSA.Common.PCL.PlatformAbstractions;
using jcMSA.Common.PCL.Transports.Container;

namespace jcMSA.Client.MVC.PlatformImplementations {
    public class WebCachePI : IBaseCachePa {
        private string generateKey(CacheItems cacheItem, object objectID = null) => (objectID == null ? cacheItem.ToString() : $"{cacheItem}_{objectID}");

        public ReturnSet<T> Get<T>(CacheItems cacheItem, object objectID = null) {
            return !Exists(cacheItem) ? new ReturnSet<T>(ErrorCodes.CACHE_KEY_NOT_FOUND) : new ReturnSet<T>((T)HttpContext.Current.Cache[generateKey(cacheItem, objectID)]);
        }

        public void Add<T>(CacheItems cacheItem, T value, object objectID = null) {
            HttpContext.Current.Cache.Add(generateKey(cacheItem, objectID), value, null, DateTime.MaxValue, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
        }

        public bool Exists(CacheItems cacheItem) => HttpContext.Current.Cache[cacheItem.ToString()] != null;
    }
}