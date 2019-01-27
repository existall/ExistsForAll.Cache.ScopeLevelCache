using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ExistsForAll.ScopeLevelCache.AspNet
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddScopeLevelCache(this IServiceCollection target)
        {
            target.AddSingleton<IScopeLevelCache, ScopeLevelCache>();
            target.AddSingleton<IScopeLevelCacheFactory, ScopeLevelCacheScopingFactory>();
            target.AddSingleton<IStartupFilter, ScopeCacheStartupFilter>();
            return target;
        }
    }
}