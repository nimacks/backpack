using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpack.Extensions
{
    /// <summary>
    /// Provides helpers for common method argument checking
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// If the provided value is out of range, raises an ArgumentOutOfRangeException
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="value">The value to check</param>
        /// <param name="min">The minimum allowed value</param>
        /// <param name="max">The maximum allowed value</param>
        /// <param name="paramName">The name of the parameter to the method</param>
        public static void InRange<T>(IComparable<T> value, T min, T max, string paramName)
        {
            if (!value.InRange(min, max))
                throw new ArgumentOutOfRangeException(paramName);
        }

        /// <summary>
        /// If the provided value is out of range, raises an ArgumentOutOfRangeException
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="value">The value to check</param>
        /// <param name="min">The minimum allowed value</param>
        /// <param name="max">The maximum allowed value</param>
        /// <param name="inclusive">Whether the range is inclusive</param>
        /// <param name="paramName">The name of the parameter to the method</param>
        public static void InRange<T>(IComparable<T> value, T min, T max, bool inclusive, string paramName)
        {
            if (!value.InRange(min, max, inclusive))
                throw new ArgumentOutOfRangeException(paramName);
        }

        /// <summary>
        /// If the provided value is null, raises an ArgumentNullException
        /// </summary>
        /// <param name="value">The value to check for null</param>
        /// <param name="paramName">The name of the parameter to the method</param>
        public static void NotNull(object value, string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// If the provided value is null or empty, raises an ArgumentNullException
        /// </summary>
        /// <param name="value">The value to check for null or empty</param>
        /// <param name="paramName">The name of the parameter to the method</param>
        public static void NotNullOrEmpty(string value, string paramName)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// If the provided value is null or has 0 length, raises an ArgumentNullException
        /// </summary>
        /// <param name="collection">The value to check for null or empty</param>
        /// <param name="paramName">The name of the parameter to the method</param>
        public static void NotNullOrEmpty(ICollection collection, string paramName)
        {
            if (collection == null || collection.Count < 1)
                throw new ArgumentNullException(paramName);
        }
    }
}
