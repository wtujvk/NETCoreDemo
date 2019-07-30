using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebuploaderUtils
{
    /// <summary>
    /// json帮助类。
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <typeparam name="T">类型。</typeparam>
        /// <param name="jsonStr">字符串。</param>
        /// <returns>目标对象。</returns>
        public static T DeserializeObject<T>(string jsonStr)
        {
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
    }
}