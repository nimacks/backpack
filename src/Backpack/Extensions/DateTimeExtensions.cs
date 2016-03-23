using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpack.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToCommonDateString(this DateTime dateTime)
        {
            return dateTime.ToString("D");
        }

        public static string ToLongDate(this DateTime dateTime)
        {
            return dateTime.ToString("F");
        }
    }
}
