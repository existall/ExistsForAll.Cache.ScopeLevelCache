using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace ExistsForAll.ScopeLevelCache.AspNet
{
    public class ScopeCacheStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                ConfigureScopeCache(builder);

                next(builder);
            };
        }

        private void ConfigureScopeCache(IApplicationBuilder builder)
        {
            builder.Use(async (context, next) =>
            {
                var factory = (IScopeLevelCacheFactory)builder.ApplicationServices.GetService(typeof(IScopeLevelCacheFactory));

                using (factory.CreateScopeLevelCacheScope())
                {
                    await next();
                }
            });
        }
    }
}
