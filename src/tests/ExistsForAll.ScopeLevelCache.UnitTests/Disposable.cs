using System;

namespace ExistsForAll.ScopeLevelCache.UnitTests
{
    internal class Disposable : IDisposable
    {
        private bool _disposed = false;

        public bool Disposed => _disposed;

        public void Dispose()
        {
            _disposed = true;
        }
    }
}