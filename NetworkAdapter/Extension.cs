using System.Collections.Generic;

namespace NetworkAdapter
{
    internal static class Extension
    {
        public static T First<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
            {
                return default;
            }

            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                return enumerator.MoveNext() ? enumerator.Current : default;
            }
        }
    }
}
