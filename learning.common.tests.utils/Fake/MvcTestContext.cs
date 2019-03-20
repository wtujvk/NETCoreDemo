using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.SessionState;
using System.Collections.Specialized;
using System.Web;
using System.Web.Routing; 

namespace learning.common.tests.utils.FaKe
{
    public class MvcTestContext
    {
        #region 测试时候需要配置的
        /*     测试时候需要配置的:   */
        string RootDir = @"";
        public static string Url = "http://localhost:80/";  
        #endregion

        RouteData _routeData;
        public MvcTestContext(ControllerBase controller, FakeHttpApplication httpApplication = null)
        {
            this.httpApplication = httpApplication;
            sessionItems = new SessionStateItemCollection();
            formParams = new NameValueCollection();
            queryStringParams = new NameValueCollection();
            cookies = new HttpCookieCollection();

            _route = new FakeRoute();
            _routeHandler=new FakeRouteHandler ();
            _routeData = new RouteData(_route, _routeHandler); 
             
            FakePrincipal fakePrincipal = new FakePrincipal(new FakeIdentity("userName"), new string[] { });
            _fakeHttpContext = new FakeHttpContext(fakePrincipal, formParams, queryStringParams, cookies, sessionItems, _routeData);
            _fake = new FakeControllerContext(_fakeHttpContext, _routeData, controller);

            controller.ControllerContext = _fake;
            _controller = controller;

            //httpApplication.Application_Start();
        }

        FakeRoute _route;
        FakeRouteHandler _routeHandler;
        FakeHttpContext _fakeHttpContext;
        public void SessionAdd(string name,object val) 
        {
            sessionItems[name] = val;
        }
        public void FormParamsAdd(string key, string val)
        {
            formParams.Add(key, val);
        }
        public void QueryStringParamsAdd(string key, string val)
        {
            queryStringParams.Add(key, val);
        }
        public void CookiesAdd(string key, string val)
        {
            HttpCookie cookie = new HttpCookie(key,val);
            cookies.Add(cookie);
        }

        public void AddRouteData(string key,object o)
        {
            _routeData.Values.Add(key,o);
        }

        public ActionExecutingContext GetActionFilter()
        {
            ActionExecutingContext aec = new ActionExecutingContext();
            aec.Controller = _controller;
            aec.RequestContext = _controller.ControllerContext.RequestContext;
            aec.HttpContext = _controller.ControllerContext.HttpContext;
            return aec;
        }


        FakeControllerContext _fake;
        SessionStateItemCollection sessionItems;
        NameValueCollection formParams;
        NameValueCollection queryStringParams;
        HttpCookieCollection cookies;
        ControllerBase _controller;
        FakeHttpApplication httpApplication;
    }
}
