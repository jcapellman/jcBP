using jcMSA.Common.PCL.Enums;
using jcMSA.Common.PCL.Transports.Container;

namespace jcMSA.Common.PCL.PlatformAbstractions {
    public interface IBaseCachePa {
        ReturnSet<T> Get<T>(CacheItems cacheItem);

        void Add<T>(CacheItems cacheItem, T value);

        bool Exists(CacheItems cacheItem);
    }
}