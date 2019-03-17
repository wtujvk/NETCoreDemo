using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcFilterDemo.Filters
{
    /// <summary>
    /// 自定义过滤器。
    /// </summary>
    public class MyOwnManyFilter : ActionFilterAttribute, IAuthorizationFilter, IExceptionFilter
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("方法名称：OnActionExecuting<br/>");
            var routeData = filterContext.RouteData.Values;
            filterContext.HttpContext.Response.Write(this.GetMessage(routeData));
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("方法名称：OnActionExecuted<br/>");
            var routeData = filterContext.RouteData.Values;
            filterContext.HttpContext.Response.Write(this.GetMessage(routeData));
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("方法名称：OnResultExecuting<br/>");
            var routeData = filterContext.RouteData.Values;
            filterContext.HttpContext.Response.Write(this.GetMessage(routeData));
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("方法名称：OnResultExecuted<br/>");
            var routeData = filterContext.RouteData.Values;
            filterContext.HttpContext.Response.Write(this.GetMessage(routeData));
            base.OnResultExecuted(filterContext);
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Write("方法名称：OnAuthorization<br/>");
            var routeData = filterContext.RouteData.Values;
            filterContext.HttpContext.Response.Write(this.GetMessage(routeData));
        }

        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Write("方法名称：OnException<br/>");
            var routeData = filterContext.RouteData.Values;
            filterContext.HttpContext.Response.Write(this.GetMessage(routeData));
            filterContext.HttpContext.Response.Write(filterContext.Exception.Message);
            //记录日志
            logger.Error(filterContext.Exception);
            //filterContext.ExceptionHandled = true;
        }

        private string GetMessage(RouteValueDictionary values)
        {
            string controllerName = values["controller"].ToString();
            string actionName = values["action"].ToString();
            string message = $"控制器:{controllerName}<br/>action:{actionName}<br/>------------------华丽的分割线------------------<br/>";
            return message;
        }
    }
}