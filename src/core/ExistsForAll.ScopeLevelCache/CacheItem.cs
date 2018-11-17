namespace ExistsForAll.ScopeLevelCache
{
    internal class CacheItem : ICacheItem
    {
        public object Item { get; set; }

        public CacheItem(object item)
        {
            Item = item;
        }
    }
}