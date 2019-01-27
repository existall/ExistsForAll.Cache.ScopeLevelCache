namespace ExistsForAll.ScopeLevelCache
{
    public class ScopeLevelCacheScopingFactory : IScopeLevelCacheFactory
    {
        public ScopeLevelCacheScopingFactory(IScopeLevelCache scopeLevelCache)
        {
            ScopeLevelCache = (ScopeLevelCache) scopeLevelCache;
        }

        internal ScopeLevelCache ScopeLevelCache { get; }

        public IScopeLevelCacheScope CreateScopeLevelCacheScope()
        {
            return new ScopeLevelCacheScope(ScopeLevelCache);
        }
    }
}