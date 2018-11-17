using System;

namespace ExistsForAll.ScopeLevelCache
{
    public static class ScopeLevelCacheExtensions
    {
        public static T GetValue<T>(this IAsyncScopeLevelCache target, string key)
        {
            return (T) target.GetValue(key);
        }

        public static bool TryGetValue<T>(this IAsyncScopeLevelCache target, string key, out T value)
        {
            var exist = target.TryGetValue(key, out var tempValue);
            value = (T) tempValue;
            return exist;
        }

        public static T GetOrAdd<T>(this IAsyncScopeLevelCache target, string key, Func<string, object> func)
        {
            return (T) target.GetOrAdd(key, func);
        }
    }
}