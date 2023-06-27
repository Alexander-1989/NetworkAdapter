namespace NetworkAdapter
{
    internal static class Extension
    {
        public static T First<T>(this T[] collection)
        {
            return collection?.Length > 0 ? collection[0] : default(T);
        }
    }
}