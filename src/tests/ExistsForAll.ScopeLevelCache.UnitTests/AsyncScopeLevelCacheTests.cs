using System;
using Xunit;

namespace ExistsForAll.ScopeLevelCache.UnitTests
{
    public class AsyncScopeLevelCacheTests
    {
        private const string SomeKey = "some-key";
        private const int SomeValue = 1;

        [Fact]
        public void SetValue_WhenCacheNotInScope_ShouldThrowException()
        {
            var sut = new ScopeLevelCache();

            Assert.Throws<InvalidOperationException>(() => sut.SetValue(SomeKey, SomeValue));
        }

        [Fact]
        public void GetValue_WhenCacheNotInScope_ShouldThrowException()
        {
            var sut = new ScopeLevelCache();

            Assert.Throws<InvalidOperationException>(() => sut.GetValue(SomeKey));
        }

        [Fact]
        public void TryGetValue_WhenCacheNotInScope_ShouldThrowException()
        {
            var sut = new ScopeLevelCache();

            Assert.Throws<InvalidOperationException>(() => sut.TryGetValue(SomeKey, out var value));
        }
    }
}