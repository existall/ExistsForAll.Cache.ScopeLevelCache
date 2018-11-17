namespace ExistsForAll.ScopeLevelCache
{
    public class ScopeLevelCacheScopingFactory : IScopeLevelCacheFactory
    {
        public ScopeLevelCacheScopingFactory(IAsyncScopeLevelCache asyncScopeLevelCache)
        {
            AsyncScopeLevelCache = (AsyncScopeLevelCache) asyncScopeLevelCache;
        }

        internal AsyncScopeLevelCache AsyncScopeLevelCache { get; }

        public IScopeLevelCacheScope CreateScopeLevelCacheScope()
        {
            return new ScopeLevelCacheScope(AsyncScopeLevelCache);
        }
    }
}