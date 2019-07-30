using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebuploaderUtils
{
    /// <summary>
    /// ueditor配置。
    /// </summary>
    public static class UeditorConfig
    {
        private static bool noCache = true;

        /// <summary>
        /// 编辑器json文件配置地址。
        /// </summary>
        public static string FilePath = "config.json";
        private static JObject BuildItems()
        {
            var json = File.ReadAllText(FilePath);
            return JObject.Parse(json);
        }

        public static JObject Items
        {
            get
            {
                if (noCache || _Items == null)
                {
                    _Items = BuildItems();
                }

                return _Items;
            }
        }

        private static JObject _Items;


        public static T GetValue<T>(string key)
        {
            return Items[key].Value<T>();
        }

        public static String[] GetStringList(string key)
        {
            return Items[key].Select(x => x.Value<String>()).ToArray();
        }

        public static String GetString(string key)
        {
            return GetValue<String>(key);
        }

        public static int GetInt(string key)
        {
            return GetValue<int>(key);
        }
    }
}