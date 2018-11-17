using System;

namespace ExistsForAll.ScopeLevelCache
{
    internal static class TypeExtensions
    {
        private static readonly string DisposableName = typeof(IDisposable).Name;

        public static bool IsDisposable(this Type type)
        {
            return type.GetInterface(DisposableName) != null;
        }
    }
}