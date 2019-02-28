using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcThrottleDemo.Codes
{
    /// <summary>
    /// 应用程序数据。
    /// </summary>
    public class AppDataInit
    {
        public static void Init()
        {
          PerSecond =  Utils.GetConfigIntValueByKey("perSecond");
          PerMinute = Utils.GetConfigIntValueByKey("perMinute");
          PerHour = Utils.GetConfigIntValueByKey("perHour");
          PerDay = Utils.GetConfigIntValueByKey("perDay");
        }

        /// <summary>
        /// 每秒请求数量。
        /// </summary>
        public static int PerSecond { get; set; }

        /// <summary>
        /// 每分请求数量。
        /// </summary>
        public static int PerMinute { get; set; }

        /// <summary>
        /// 每小时请求数量。
        /// </summary>
        public static int PerHour { get; set; }

        /// <summary>
        /// 每天请求数量。
        /// </summary>
        public static int PerDay { get; set; }
    }
}