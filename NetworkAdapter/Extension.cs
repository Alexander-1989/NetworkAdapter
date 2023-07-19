using System.Collections.Generic;

namespace NetworkAdapter
{
    internal static class Extension
    {
        public static T First<T>(this IEnumerable<T> collection)
        {
            IEnumerator<T> enumerator = collection?.GetEnumerator();
            return enumerator == null || !enumerator.MoveNext() ? default : enumerator.Current;
        }
    }
}
