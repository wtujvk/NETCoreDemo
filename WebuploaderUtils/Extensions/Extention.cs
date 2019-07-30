using System;
using System.Collections.Generic;

namespace WebuploaderUtils.Extensions
{
    public static class Extension
    {
        public static string String(this decimal t)
        {
            return t.ToString("#,###.##");
        }

        public static string String(this decimal? t)
        {
            return t.HasValue ? String(t.Value) : string.Empty;
        }

        public static string String(this DateTime t, string format = null)
        {
            return t.ToString(format ?? "yyyy-MM-dd");
        }

        public static string YearMonth(this DateTime t, bool delimeter = true)
        {
            return t.ToString(delimeter ? "yyyy-MM" : "yyyyMM");
        }

        public static string String(this DateTime? t, string format = null)
        {
            return t.HasValue ? String(t.Value, format) : string.Empty;
        }

        public static string Format(this string s, params object[] args)
        {
            return string.Format(s, args);
        }

        public static void Each<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null) return;

            foreach (var o in collection)
                action(o);
        }

        public static void Each<T>(this IEnumerable<T> collection, Action<int, T> action)
        {
            if (collection == null) return;
            int i = 0;

            foreach (var o in collection)
                action(i++, o);
        }
    }
}