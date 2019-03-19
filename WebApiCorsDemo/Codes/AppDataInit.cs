using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebApiCorsDemo.Codes
{
    /// <summary>
    /// 应用程序数据。
    /// </summary>
    public class AppDataInit
    {
        /// <summary>
        /// 认证密钥。
        /// </summary>
        public static string AccessKeyValue = WebConfigurationManager.AppSettings["AccessKeyValue"];
    }
}