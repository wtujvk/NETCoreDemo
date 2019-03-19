using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Newtonsoft.Json;
using WebApiCorsDemo.Codes;

namespace WebApiCorsDemo.Utility
{
    /// <summary>
    /// 权限验证。
    /// </summary>
    public class AccessKeyAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            var accessKey = string.Empty;
            if (request.Headers.Contains("access-key"))
            {
                accessKey = request.Headers.GetValues("access-key").FirstOrDefault();
            }
            else
            {
                var qryParams = request.GetQueryNameValuePairs();
                accessKey = qryParams.Where(c => c.Key == "api_key").Select(c => c.Value).FirstOrDefault(); //浏览器上方的api_key
            }

            //验证
            return string.Equals(accessKey, AppDataInit.AccessKeyValue,StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        ///  处理未授权的请求
        /// </summary>
        /// <param name="actionContext"></param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var content = JsonConvert.SerializeObject(new {State = HttpStatusCode.Unauthorized});
            actionContext.Response = new HttpResponseMessage
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.Unauthorized
            };
        }
    }
}