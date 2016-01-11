using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpack.Extensions
{
    /// <summary>
    /// Extension methods for common tasks related to number types
    /// </summary>
    public static class NumberExtensions
    {
        /// <summary>
        /// Returns the number with the English ordinal suffix appended.  For example,
        /// 1 becomes 1st, 2 becomes 2nd, etc.
        /// </summary>
        /// <param name="number">The number to convert to ordinal</param>
        /// <remarks>Right now, this method only supports English language.</remarks>
        /// <returns>An ordinal number string</returns>
        public static string ToOrdinalString(this short number)
        {
            return ToOrdinalString((long)number);
        }

        /// <summary>
        /// Returns the number with the English ordinal suffix appended.  For example,
        /// 1 becomes 1st, 2 becomes 2nd, etc.
        /// </summary>
        /// <param name="number">The number to convert to ordinal</param>
        /// <remarks>Right now, this method only supports English language.</remarks>
        /// <returns>An ordinal number string</returns>
        public static string ToOrdinalString(this int number)
        {
            return ToOrdinalString((long)number);
        }

        /// <summary>
        /// Returns the number with the English ordinal suffix appended.  For example,
        /// 1 becomes 1st, 2 becomes 2nd, etc.
        /// </summary>
        /// <param name="number">The number to convert to ordinal</param>
        /// <remarks>Right now, this method only supports English language.</remarks>
        /// <returns>An ordinal number string</returns>
        public static string ToOrdinalString(this long number)
        {
            string suffix = GetOrdinalSuffix(number);
            return number + suffix;
        }

        private static string GetOrdinalSuffix(long number)
        {
            switch (number % 100)
            {
                case 11:
                case 12:
                case 13:
                    return "th";
            }

            switch (number % 10)
            {
                case 1:
                    return "st";
                case 2:
                    return "nd";
                case 3:
                    return "rd";
                default:
                    return "th";
            }
        }

        /// <summary>
        /// Returns whether the provided value is between the minimum and maximum values
        /// </summary>
        /// <typeparam name="T">The type of the range values</typeparam>
        /// <param name="value">The value to compare</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>Whether the value falls in the range, inclusively</returns>
        public static bool InRange<T>(this IComparable<T> value, T min, T max)
        {
            return InRange(value, min, max, true);
        }

        /// <summary>
        /// Returns whether the provided value is between the minimum and maximum values
        /// </summary>
        /// <typeparam name="T">The type of the range values</typeparam>
        /// <param name="value">The value to compare</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <param name="inclusive">True to check inclusively, false to check only between</param>
        /// <returns>Whether the value falls in the range</returns>
        public static bool InRange<T>(this IComparable<T> value, T min, T max, bool inclusive)
        {
            Guard.NotNull(value, "value");

            int minCompare = value.CompareTo(min);
            int maxCompare = value.CompareTo(max);

            if (inclusive)
            {
                return minCompare >= 0 && maxCompare <= 0;
            }
            else
            {
                return minCompare > 0 && maxCompare < 0;
            }
        }
    }
}
