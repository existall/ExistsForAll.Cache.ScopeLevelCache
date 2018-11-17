using System.Collections.Concurrent;

namespace ExistsForAll.ScopeLevelCache
{
    internal class ScopeLevelCacheScope : IScopeLevelCacheScope
    {
        public AsyncScopeLevelCache Cache { get; }

        public ScopeLevelCacheScope(AsyncScopeLevelCache cache)
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