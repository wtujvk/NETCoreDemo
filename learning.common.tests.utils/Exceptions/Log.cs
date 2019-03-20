using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Diagnostics;
using learning.common.tests.utils.Exceptions;

namespace learning.common.tests.utils.Exceptions
{
    public class Log
    {
        /// <summary>
        /// 设置写入路径
        /// {0}日期
        /// </summary>
        public static string LogWritePath
        {
            get;
            set;
        }
        /// <summary>
        /// 将错误信息写入到日志，需要先配置com.yajingling.Exception.Log.LogWritePath
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        public static void WriteFile(Exception exception = null, string Desc = null)
        {
            string estr = string.Empty;
            try
            {
                HttpContext context = System.Web.HttpContext.Current;
                EToString etostring = null;
                if (exception == null)
                {
                    etostring = new EToString(context);
                }
                else
                {
                    etostring = new EToString(context, exception);
                }
                estr = etostring.ToString();
                if (Desc != null)
                {
                    estr = estr + "\r\n" + Desc;
                }
                string path = string.Format(LogWritePath, DateTime.Now);
                string dir = path.Substring(0, path.LastIndexOf("\\"));
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                File.AppendAllText(path, estr);
            }
            catch (Exception ex)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("\r\n  错误信息>{0}", ex.Message);
                    sb.AppendFormat("\r\n  错误源>{0}", ex.Source);
                    sb.AppendFormat("\r\n  异常方法>{0}", ex.TargetSite);
                    sb.AppendFormat("\r\n  堆栈信息>");
                    sb.AppendFormat("\r\n{0}", ex.StackTrace);
                    sb.AppendFormat("\r\n  原错误{0}", estr);
                    string logestr = sb.ToString();
                    EventLog.WriteEntry("牙精灵-诊所", logestr, EventLogEntryType.Error);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
