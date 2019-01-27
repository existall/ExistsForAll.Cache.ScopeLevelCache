using System;

namespace ExistsForAll.ScopeLevelCache
{
    public interface IScopeLevelCache
    {
        void SetValue(string key, object value);
        void SetDisposableValue(string key, IDisposable value);
        object GetValue(string key);
        bool TryGetValue(string key, out object value);
        object GetOrAdd(string key, Func<string, object> action);
    }
}