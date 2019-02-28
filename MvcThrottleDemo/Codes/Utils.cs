using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MvcThrottleDemo.Codes
{
    /// <summary>
    /// 工具类。
    /// </summary>
    public class Utils
    {
        public static string GetConfigValueByKey(string key, string def = "")
        {
            try
            {
                var key0 = ConfigurationManager.AppSettings[key];
                if (!string.IsNullOrWhiteSpace(key0))
                {
                    def = key0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return def;
        }

        public static int GetConfigIntValueByKey(string key, int def = 0)
        {
            try
            {
                var key0 = ConfigurationManager.AppSettings[key];
                if (!string.IsNullOrWhiteSpace(key0) && int.TryParse(key0, out def))
                {
                }
            }
            catch (Exception)
            {
                throw;
            }

            return def;
        }
    }
}