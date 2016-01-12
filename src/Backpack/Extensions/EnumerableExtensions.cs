using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpack.Extensions
{
    /// <summary>
    /// Useful extensions for enumerables
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Adding the missing AddRange method (for types that don't already have it)
        /// </summary>
        /// <typeparam name="T">The type of items in the collection</typeparam>
        /// <param name="collection">The collection to add items to</param>
        /// <param name="items">The items to add to the collection</param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (T t in items)
                collection.Add(t);
        }

        /// <summary>
        /// Tries to retrieve an item from the provided dictionary, or will build the object and add to the dictionary if not found
        /// </summary>
        /// <typeparam name="TKey">Type of the key of the item to find</typeparam>
        /// <typeparam name="TResult">Type of the item to find</typeparam>
        /// <param name="dict">Dictionary to search for the item</param>
        /// <param name="key">The key of the item in question</param>
        /// <param name="factory">Method to create the item, if not found</param>
        /// <returns>The item found in dictionary or built and added to dictionary</returns>
        public static TResult GetOrAdd<TKey, TResult>(this IDictionary<TKey, TResult> dict, TKey key, Func<TKey, TResult> factory)
        {
            TResult result;
            if (!dict.TryGetValue(key, out result))
            {
                result = factory(key);
                dict.Add(key, result);
            }
            return result;
        }


        /// <summary>
        /// Tries to retrieve an item from the provided dictionary, or will return default value if not found
        /// </summary>
        /// <typeparam name="TKey">Type of the key of the item to find</typeparam>
        /// <typeparam name="TResult">Type of the item to find</typeparam>
        /// <param name="dict">Dictionary to search for the item</param>
        /// <param name="key">The key of the item in question</param>
        /// <param name="defaultValue">Item to return if the item is not found</param>
        /// <returns>The item found in dictionary or the defaultValue</returns>
        public static TResult GetOrDefault<TKey, TResult>(this IDictionary<TKey, TResult> dict, TKey key, TResult defaultValue = default(TResult))
        {
            TResult result;
            if (dict.TryGetValue(key, out result))
                return result;

            return defaultValue;
        }

        /// <summary>
        /// Checks if an item exists in the dictionary and is the same as the provided value
        /// </summary>
        /// <typeparam name="TKey">Type of the key of the item to find</typeparam>
        /// <typeparam name="TValue">Type of the value to find</typeparam>
        /// <param name="dict">Dictionary to search for the item</param>
        /// <param name="key">The key of the item in question</param>
        /// <param name="value">The value in the dictionary to verify</param>
        /// <returns>Whether the item was found and has the same value as specified</returns>
        public static bool HasValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            return HasValue<TKey, TValue>(dict, key, value, EqualityComparer<TValue>.Default);
        }

        /// <summary>
        /// Checks if an item exists in the dictionary and is the same as the provided value, using the specified equality comparer
        /// </summary>
        /// <typeparam name="TKey">Type of the key of the item to find</typeparam>
        /// <typeparam name="TValue">Type of the value to find</typeparam>
        /// <param name="dict">Dictionary to search for the item</param>
        /// <param name="key">The key of the item in question</param>
        /// <param name="value">The value in the dictionary to verify, using the comparer</param>
        /// <param name="comparer">Equality comparer to use to compare the value to the item found</param>
        /// <returns>Whether the item was found and has the same value as specified based on provided comparison</returns>
        public static bool HasValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value, IEqualityComparer<TValue> comparer)
        {
            TValue s;
            return dict.TryGetValue(key, out s) && comparer.Equals(s, value);
        }

        /// <summary>
        /// Tries to retrieve an item from the provided keyed collection, or will return default value if not found
        /// </summary>
        /// <typeparam name="TKey">Type of the key of the item to find</typeparam>
        /// <typeparam name="TResult">Type of the item to find</typeparam>
        /// <param name="collection">Keyed collection to search for the item</param>
        /// <param name="key">The key of the item in question</param>
        /// <param name="defaultValue">Item to return if the item is not found</param>
        /// <returns>The item found in keyed collection or the defaultValue</returns>
        public static TResult GetOrDefault<TKey, TResult>(this KeyedCollection<TKey, TResult> collection, TKey key, TResult defaultValue = default(TResult))
        {
            if (collection.Contains(key))
                return collection[key];

            return defaultValue;
        }

        /// <summary>
        /// Tries to locate all items in the lookup with the specified key, or returns an empty enumerable if not found
        /// </summary>
        /// <typeparam name="TKey">Type of the key of the items to find</typeparam>
        /// <typeparam name="TValue">Type of the values to find</typeparam>
        /// <param name="dict">Lookup to search for the items</param>
        /// <param name="key">The key of the items in question</param>
        /// <returns>Any items in the lookup with the specified key, or empty if none found</returns>
        public static IEnumerable<TValue> GetOrEmpty<TKey, TValue>(this ILookup<TKey, TValue> dict, TKey key)
        {
            if (dict.Contains(key))
                return dict[key];

            return Enumerable.Empty<TValue>();
        }

        /// <summary>
        /// Split the provided list into multiple lists, based on the desired number of items per list.
        /// </summary>
        /// <typeparam name="T">Type of items in list</typeparam>
        /// <param name="list">Source list of items to split into multiple lists</param>
        /// <param name="itemsPerList">Number of items per list</param>
        /// <returns>A sequence of lists with items in the same order as the source list, with no single list having more than itemsPerList items</returns>
        public static IEnumerable<List<T>> SegmentList<T>(this List<T> list, int itemsPerList)
        {
            for (int i = 0; i < Math.Ceiling((decimal)list.Count / itemsPerList); i++)
            {
                int index = i * itemsPerList;
                int count = Math.Min(index + itemsPerList, list.Count) - index;

                var segment = list.GetRange(index, count);
                yield return segment;
            }
        }

        /// <summary>
        /// Returns the ordinal position of a specified item in a sequence
        /// </summary>
        /// <typeparam name="TValue">Type of the items in the source</typeparam>
        /// <param name="source">The items to search for the specified value</param>
        /// <param name="item">The item to search within the source for</param>
        /// <returns>The ordinal of the item in the source, or -1 indicating not found</returns>
        public static int IndexOf<TValue>(this IEnumerable<TValue> source, TValue item)
        {
            return IndexOf(source, item, EqualityComparer<TValue>.Default);
        }

        /// <summary>
        /// Returns the ordinal position of a specified item in a sequence based on the provided comparison
        /// </summary>
        /// <typeparam name="TValue">Type of the items in the source</typeparam>
        /// <param name="source">The items to search for the specified value</param>
        /// <param name="item">The item to search within the source for</param>
        /// <param name="comparer">Equality comparer to use to compare the value to the item found</param>
        /// <returns>The ordinal of the item in the source based on the comparison, or -1 indicating not found</returns>
        public static int IndexOf<TValue>(this IEnumerable<TValue> source, TValue item, IEqualityComparer<TValue> comparer)
        {
            int i = 0;
            foreach (TValue v in source)
            {
                if (comparer.Equals(v, item))
                    return i;
                i++;
            }

            return -1;
        }
    
    
    }

}
