using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ExistsForAll.ScopeLevelCache
{
    public class AsyncScopeLevelCache : IAsyncScopeLevelCache
    {
        private readonly AsyncLocal<ConcurrentDictionary<string, ICacheItem>> _cache =
            new AsyncLocal<ConcurrentDictionary<string, ICacheItem>>();

        internal ConcurrentDictionary<string, ICacheItem> Cache
        {
            set => _cache.Value = value;

            get => _cache.Value;
        }

        public void SetValue(string key, object value)
        {
            ValidateCacheExistence();
            if (key == null) throw new ArgumentNullException(nameof(key));

            Cache.AddOrUpdate(key, new CacheItem(value), (s, o) => new CacheItem(value));
        }

        public void SetDisposableValue(string key, IDisposable value)
        {
            ValidateCacheExistence();
            if (key == null) throw new ArgumentNullException(nameof(key));

            Cache.AddOrUpdate(key, new DisposableCacheItem(value), (s, o) => new CacheItem(value));
        }

        public object GetValue(string key)
        {
            ValidateCacheExistence();

            if (key == null) throw new ArgumentNullException(nameof(key));

            Cache.TryGetValue(key, out var value);

            return value?.Item;
        }

        public object GetOrAdd(string key, Func<string, object> action)
        {
            ValidateCacheExistence();

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var value = Cache.GetOrAdd(key, s => new CacheItem(action(s)));

            return value.Item;
        }

        public bool TryGetValue(string key, out object value)
        {
            ValidateCacheExistence();

            if (key == null) throw new ArgumentNullException(nameof(key));

            value = null;

            var success = Cache.TryGetValue(key, out ICacheItem cacheItem);

            if (!success)
                return false;

            value = cacheItem?.Item;
            return true;
        }

        private void ValidateCacheExistence()
        {
            if (Cache == null)
                throw new InvalidOperationException(Resources.CacheNotInitiazliedMessage());
        }
    }
}