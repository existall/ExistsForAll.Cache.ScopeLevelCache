using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ExistsForAll.ScopeLevelCache.AspNet
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddScopeLevelCache(this IServiceCollection target)
        {
            target.AddSingleton<IAsyncScopeLevelCache, AsyncScopeLevelCache>();
            target.AddSingleton<IScopeLevelCacheFactory, ScopeLevelCacheScopingFactory>();
            target.AddSingleton<IStartupFilter, ScopeCacheStartupFilter>();
            return target;
        }
    }
}