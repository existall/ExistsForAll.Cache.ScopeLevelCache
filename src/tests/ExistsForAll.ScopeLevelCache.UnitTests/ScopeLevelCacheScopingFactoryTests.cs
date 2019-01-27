using System;
using Xunit;

namespace ExistsForAll.ScopeLevelCache.UnitTests
{
    public class ScopeLevelCacheScopingFactoryTests
    {
        private const string SomeKey = "some-key";
        private const int SomeValue = 1;
        private const int NewValue = 2;

        [Fact]
        public void SetValue_WhenCacheInScope_ShouldReturnValue()
        {
            var sut = BuildSut();
            var cache = sut.ScopeLevelCache;

            using (sut.CreateScopeLevelCacheScope())
            {
                cache.SetValue(SomeKey, SomeValue);
                var result = cache.GetValue(SomeKey);

                Assert.Equal(SomeValue, result);
            }

            Assert.Throws<InvalidOperationException>(() => cache.GetValue(SomeKey));
        }

        [Fact]
        public void SetValue_WhenCacheInScopeAndUpdateValue_ShouldReturnNewValue()
        {
            var sut = BuildSut();
            var cache = sut.ScopeLevelCache;

            using (sut.CreateScopeLevelCacheScope())
            {
                cache.SetValue(SomeKey, SomeValue);
                cache.SetValue(SomeKey, NewValue);
                var result = cache.GetValue(SomeKey);

                Assert.Equal(NewValue, result);
            }

            Assert.Throws<InvalidOperationException>(() => cache.GetValue(SomeKey));
        }

        [Fact]
        public void TryGetValue_WhenCacheInScope_ShouldReturnValue()
        {
            var sut = BuildSut();
            var cache = sut.ScopeLevelCache;

            using (sut.CreateScopeLevelCacheScope())
            {
                cache.SetValue(SomeKey, SomeValue);
                var success = cache.TryGetValue(SomeKey, out var result);

                Assert.Equal(SomeValue, result);
                Assert.True(success);
            }

            Assert.Throws<InvalidOperationException>(() => cache.GetValue(SomeKey));
        }

        [Fact]
        public void TryGetValue_WhenCacheInScopeAndUpdateValue_ShouldReturnNewValue()
        {
            var sut = BuildSut();
            var cache = sut.ScopeLevelCache;

            using (sut.CreateScopeLevelCacheScope())
            {
                cache.SetValue(SomeKey, SomeValue);
                cache.SetValue(SomeKey, NewValue);
                var success = cache.TryGetValue(SomeKey, out var result);

                Assert.Equal(NewValue, result);
                Assert.True(success);
            }

            Assert.Throws<InvalidOperationException>(() => cache.GetValue(SomeKey));
        }

        [Fact]
        public void TryGetValue_WhenCacheInScopeAndValueWasNotSet_ShouldReturnFalse()
        {
            var sut = BuildSut();
            var cache = sut.ScopeLevelCache;

            using (sut.CreateScopeLevelCacheScope())
            {
                var success = cache.TryGetValue(SomeKey, out var result);

                Assert.Null(result);
                Assert.False(success);
            }

            Assert.Throws<InvalidOperationException>(() => cache.GetValue(SomeKey));
        }

        [Fact]
        public void Dispose_WhenCacheScopeEnds_ShouldDisposeCache()
        {
            var sut = BuildSut();
            var cache = sut.ScopeLevelCache;
            var disposable = new Disposable();

            using (sut.CreateScopeLevelCacheScope())
            {
                cache.SetDisposableValue(SomeKey, disposable);

                Assert.False(disposable.Disposed);
            }

            Assert.True(disposable.Disposed);
        }

        private ScopeLevelCacheScopingFactory BuildSut()
        {
            return new ScopeLevelCacheScopingFactory(new ScopeLevelCache());
        }
    }
}