using System;
using System.Web;
using System.Web.Mvc;

namespace learning.forTest.mvcDemo.Codes.Attributes
{
    /// <summary>
    /// 验证。
    /// </summary>
    public class LoginVerifyFilterAttribute : AuthorizeAttribute
    {
        private bool white = false;
        /// <param name="white">是否白名单</param>
        public LoginVerifyFilterAttribute(bool white = false)
        {
            this.white = white;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (white) return true;
            return httpContext.Session[AppDataInit.LoginSessionKey] != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // base.HandleUnauthorizedRequest(filterContext);
            string sheader = filterContext.RequestContext.HttpContext.Request.Headers["X-Requested-With"];
            if (sheader != null && sheader == "XMLHttpRequest")
            {
                filterContext.HttpContext.Response.Write("<script type=\"text/javascript\">    top.location.href = \"/\";</script>");
                filterContext.Result = new EmptyResult();
                return;
            }
            else
            {
                filterContext.Result=new RedirectResult("/login");
            }
        }
    }
}