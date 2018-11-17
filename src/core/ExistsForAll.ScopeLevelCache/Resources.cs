namespace ExistsForAll.ScopeLevelCache
{
    internal static class Resources
    {
        public static string CacheNotInitiazliedMessage()
        {
            return
                "AsyncScopeLevelCache was not initlized at the start of the scope, use sevices.AddAsyncScopeLevelCache() extension method on Statup file" +
                "If the usage is on a custom scope please use ScopeLevelCacheScopingFactory.CreateScopeLevelCacheScope() at the beginning of the scope";
        }
    }
}