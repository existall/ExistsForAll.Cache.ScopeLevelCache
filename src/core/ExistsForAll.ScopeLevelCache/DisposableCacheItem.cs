using System;

namespace ExistsForAll.ScopeLevelCache
{
    internal class DisposableCacheItem : ICacheItem, IDisposable
    {
        public object Item { get; set; }

        public DisposableCacheItem(IDisposable item)
        {
            Item = item;
        }

        public void Dispose()
        {
            (Item as IDisposable)?.Dispose();
        }
    }
}