using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebuploaderUtils.Extensions
{
    /// <summary>
    /// 数组扩展方法
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// 返回字符串在数组中的索引
        /// </summary>
        /// <param name="array">数组。</param>
        /// <param name="value">要搜索 的值。</param>
        /// <returns>索引位置。</returns>
        public static int ArrayIndexOf(this string[] array, string value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}