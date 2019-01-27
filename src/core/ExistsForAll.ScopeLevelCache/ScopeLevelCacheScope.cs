using System.Collections.Concurrent;

namespace ExistsForAll.ScopeLevelCache
{
    internal class ScopeLevelCacheScope : IScopeLevelCacheScope
    {
        public ScopeLevelCache Cache { get; }

        public ScopeLevelCacheScope(ScopeLevelCache cache)
        {
            cache.Cache = new ConcurrentDictionary<string, ICacheItem>();
            Cache = cache;
        }

        public void Dispose()
        {
            if (Cache?.Cache == null)
                return;

            foreach (var item in Cache.Cache)
            {
                var disposable = item.Value as DisposableCacheItem;
                disposable?.Dispose();
            }

            Cache.Cache = null;
        }
    }
}