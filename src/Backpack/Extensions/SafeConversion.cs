using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpack.Extensions
{
    /// <summary>
    /// Methods to do conversion between types generically
    /// </summary>
    /// <remarks>TODO: port from Pop.Data</remarks>
    public static class SafeConversion
    {
        /// <summary>
        /// Tries to convert the provided item to the given type
        /// </summary>
        /// <typeparam name="T">The type to try to convert to</typeparam>
        /// <param name="value">The value to convert</param>
        /// <param name="item">The result of the conversion, or default</param>
        /// <returns>Whether the conversion succeeded</returns>
        public static bool TryConvert<T>(object value, out T item)
        {
            if (value is T)
            {
                item = (T)value;
                return true;
            }

            object o;
            bool result = TryConvert(typeof(T), value, out o);

            item = result ? (T)o : default(T);
            return result;
        }

        /// <summary>
        /// Tries to convert the provided item to the given type
        /// </summary>
        /// <param name="targetType">The type to try to convert to</param>
        /// <param name="value">The value to convert</param>
        /// <param name="item">The result of the conversion, or null</param>
        /// <returns>Whether the conversion succeeded</returns>
        public static bool TryConvert(Type targetType, object value, out object item)
        {
            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter(value);
                if (converter.CanConvertTo(targetType))
                {
                    item = converter.ConvertTo(value, targetType);
                    return true;
                }
                else if (value != null)
                {
                    Type inputType = value.GetType();
                    converter = TypeDescriptor.GetConverter(targetType);
                    if (converter.CanConvertFrom(inputType))
                    {
                        item = converter.ConvertFrom(value);
                        return true;
                    }
                }
            }
            catch
            {

            }
            item = null;
            return false;
        }

        /// <summary>
        /// Tries to parse the provided string to the given type
        /// </summary>
        /// <typeparam name="T">The type to try to convert to</typeparam>
        /// <param name="value">The string to parse</param>
        /// <param name="item">The result of the conversion, or default</param>
        /// <returns>Whether the parsing succeeded</returns>
        public static bool TryParse<T>(string value, out T item)
        {
            return TryParse(value, out item, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Tries to parse the provided string to the given type
        /// </summary>
        /// <typeparam name="T">The type to try to convert to</typeparam>
        /// <param name="value">The string to parse</param>
        /// <param name="item">The result of the conversion, or default</param>
        /// <param name="culture">The culture to use when converting</param>
        /// <returns>Whether the parsing succeeded</returns>
        public static bool TryParse<T>(string value, out T item, CultureInfo culture)
        {
            object outputValue;
            bool result = TryParse(typeof(T), value, out outputValue, culture);
            item = result ? (T)outputValue : default(T);
            return result;
        }


        /// <summary>
        /// Tries to parse the provided string to the given type
        /// </summary>
        /// <param name="type">The type to try to convert to</param>
        /// <param name="value">The string to parse</param>
        /// <param name="item">The result of the conversion, or null</param>
        /// <returns>Whether the parsing succeeded</returns>
        public static bool TryParse(Type type, string value, out object item)
        {
            return TryParse(type, value, out item, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Tries to parse the provided string to the given type
        /// </summary>
        /// <param name="type">The type to try to convert to</param>
        /// <param name="value">The string to parse</param>
        /// <param name="item">The result of the conversion, or null</param>
        /// <param name="culture">The culture to use when converting</param>
        /// <returns>Whether the parsing succeeded</returns>
        public static bool TryParse(Type type, string value, out object item, CultureInfo culture)
        {
            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter(type);
                item = converter.ConvertFromString(null, culture, value);
                return true;
            }
            catch
            {
                item = null;
                return false;
            }
        }

        /// <summary>
        /// Parse the provided string as the specified type, or return default value if unable to parse
        /// </summary>
        /// <typeparam name="T">The type to parse the string as</typeparam>
        /// <param name="value">The string to parse</param>
        /// <returns>The value of the string if parsed successfully, or the default value for the type</returns>
        public static T ParseOrDefault<T>(this string value)
        {
            return ParseOrDefault<T>(value, default(T));
        }

        /// <summary>
        /// Parse the provided string as the specified type, or return provided default value if unable to parse
        /// </summary>
        /// <typeparam name="T">The type to parse the string as</typeparam>
        /// <param name="value">The string to parse</param>
        /// <param name="defaultValue">Value to return if parsing is unsuccessful</param>
        /// <returns>The value of the string if parsed successfully, or the default value provided.</returns>
        public static T ParseOrDefault<T>(this string value, T defaultValue)
        {
            return ParseOrDefault<T>(value, defaultValue, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Parse the provided string as the specified type with the specified culture, or return provided default value if unable to parse
        /// </summary>
        /// <typeparam name="T">The type to parse the string as</typeparam>
        /// <param name="value">The string to parse</param>
        /// <param name="defaultValue">Value to return if parsing is unsuccessful</param>
        /// <param name="culture">Culture to use to parse the string</param>
        /// <returns>The value of the string if parsed successfully using the provided culture, or the default value provided.</returns>
        public static T ParseOrDefault<T>(this string value, T defaultValue, CultureInfo culture)
        {
            T item;
            if (TryParse<T>(value, out item, culture))
                return item;

            return defaultValue;
        }
    }
}
