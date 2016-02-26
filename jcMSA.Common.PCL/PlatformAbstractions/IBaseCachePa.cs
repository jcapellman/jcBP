using jcMSA.Common.PCL.Enums;
using jcMSA.Common.PCL.Transports.Container;

namespace jcMSA.Common.PCL.PlatformAbstractions {
    public interface IBaseCachePa {
        ReturnSet<T> Get<T>(CacheItems cacheItem, object objectID = null);

        void Add<T>(CacheItems cacheItem, T value, object objectID = null);

        bool Exists(CacheItems cacheItem);
    }
}