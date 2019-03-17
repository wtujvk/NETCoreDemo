using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiCorsDemo
{
    /// <summary>
    /// webapi配置。
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// 注册。
        /// </summary>
        /// <param name="config">配置。</param>
        public static void Register(HttpConfiguration config)
        {
            var allowOrigins = "http://localhost:15520,http://localhost:15521";
            var allowHeaders = "*";
            var allowMethods = "*";
            var cors = new EnableCorsAttribute(allowOrigins, allowHeaders, allowMethods);
            config.EnableCors(cors);
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
