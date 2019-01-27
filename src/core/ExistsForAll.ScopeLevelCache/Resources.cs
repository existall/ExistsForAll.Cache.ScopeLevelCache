namespace ExistsForAll.ScopeLevelCache
{
    internal static class Resources
    {
        public static string CacheNotInitializedMessage()
        {
            return
                "ScopeLevelCache was not initialized at the start of the scope, use services.AddAsyncScopeLevelCache() extension method on Startup file" +
                "If the usage is on a custom scope please use ScopeLevelCacheScopingFactory.CreateScopeLevelCacheScope() at the beginning of the scope";
        }
    }
}