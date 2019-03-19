using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace WebApiCorsDemo.Utility
{
    /// <summary>
    /// api全局异常过滤器。
    /// </summary>
    public class ApiHandleErrorAttribute:ExceptionFilterAttribute
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            //return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
             logger.Error(actionExecutedContext.Exception);
            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}