using System;
namespace Drastic.IGListKitSample.macOS
{
    using System;
    using System.Collections.Generic;
    using Foundation;

    public static class CollectionExtensions
    {
        /// <summary>
        /// Shuffles the contents of this collection.
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public static class SequenceExtensions
    {
        /// <summary>
        /// Returns an array with the contents of this sequence, shuffled.
        /// </summary>
        public static T[] Shuffled<T>(this IEnumerable<T> source)
        {
            List<T> list = new List<T>(source);
            list.Shuffle();
            return list.ToArray();
        }
    }

    public static class IndexSetExtensions
    {
        public static NSIndexSet Zero
        {
            get { return NSIndexSet.FromIndex(0); }
        }
    }
}

