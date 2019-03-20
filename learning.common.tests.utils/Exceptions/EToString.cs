using System;
using System.Text;
using System.Web;

namespace learning.common.tests.utils.Exceptions
{
    public class EToString
    {
        private HttpContext _context;
        private System.Exception _exception;
        public EToString(HttpContext context)
        {
            _context = context;
            _exception = context.Server.GetLastError().GetBaseException();
        }
        public EToString(HttpContext context, System.Exception exception)
        {
            _context = context;
            _exception = exception.GetBaseException();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\r\n\r\n-------------------------------------------------------------------------");
            sb.AppendFormat("\r\n{0:yyyy.MM.dd HH:mm:ss}", DateTime.Now);
            sb.AppendFormat("\r\n.客户：");
            try
            {
                sb.Append(GetHttpContext(_context));
            }
            catch (Exception)
            {
            }
            sb.AppendFormat("\r\n.异常：");
            try
            {
                sb.Append(GetException(_exception));
            }
            catch (Exception)
            {
            }
            return sb.ToString();
        }


        /// <summary>
        /// 获取请求上下文的信息
        /// </summary>
        private StringBuilder GetHttpContext(HttpContext Context)
        {
            StringBuilder sb = new StringBuilder();
            if (Context == null)
            {
                sb.AppendFormat("Context为null");
                return sb;
            }
            HttpRequest Request = Context.Request;
            string ip = "";
            if (Request.ServerVariables.Get("HTTP_X_FORWARDED_FOR") != null)
            {
                ip = Request.ServerVariables.Get("HTTP_X_FORWARDED_FOR").ToString().Trim();
            }
            else
            {
                ip = Request.ServerVariables.Get("Remote_Addr").ToString().Trim();
            }
            sb.AppendFormat("\r\nurl1:{0}", Request.Url.ToString());
            sb.AppendFormat("\r\nurl2:{0}", Request.UrlReferrer == null ? string.Empty : Request.UrlReferrer.ToString());
            sb.AppendFormat("\r\nIp:{0}", ip);

            string sheader = Request.Headers["X-Requested-With"];
            if (sheader != null && sheader == "XMLHttpRequest")
            {
                sheader = "ajax请求-" + sheader;
            }

            sb.AppendFormat("\r\n请求类型:{0}", sheader);

            sb.AppendFormat("\r\n浏览器:{0}", Request.Browser.Browser.ToString());
            sb.AppendFormat("\r\n浏览器版本:{0}", Request.Browser.MajorVersion.ToString());
            sb.AppendFormat("\r\n操作系统:{0}", Request.Browser.Platform.ToString());
            return sb;
        }


        /// <summary>
        /// 获取异常信息
        /// </summary>
        /// <returns></returns>
        private StringBuilder GetException(System.Exception ex)
        {

            StringBuilder sb = new StringBuilder();
            if (ex == null)
            {
                sb.AppendFormat("\r\n没有异常信息");
                return sb;
            }
            sb.AppendFormat("\r\n  错误信息>{0}", ex.Message);
            sb.AppendFormat("\r\n  异常类>{0}", ex.GetType().ToString());
            if (ex is CustomerException)
            {
                CustomerException ex2 = ex as CustomerException;
                if (ex2 != null)
                {
                    sb.AppendFormat("\r\n  异常参数>");
                    foreach (var item in ex2.Keys)
                    {
                        sb.AppendFormat("\r\n    >{0}={1}", item, ex2[item]);
                    }
                }
            }

            sb.AppendFormat("\r\n  错误源>{0}", ex.Source);
            sb.AppendFormat("\r\n  异常方法>{0}", ex.TargetSite);
            sb.AppendFormat("\r\n  堆栈信息>");
            sb.AppendFormat("\r\n{0}", ex.StackTrace);
            return sb;
        }
    }
}
