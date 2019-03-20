using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Web.Routing;

namespace learning.common.tests.utils.FaKe
{
    public class FakeHttpRequest : HttpRequestBase
    {
        private readonly NameValueCollection _formParams;
        private readonly NameValueCollection _queryStringParams;
        private readonly HttpCookieCollection _cookies;
        private readonly Uri _url;
        RequestContext _requestContext;

        public FakeHttpRequest(NameValueCollection formParams, NameValueCollection queryStringParams, HttpCookieCollection cookies,HttpContextBase httpContext, RouteData routeData)
        {
            _formParams = formParams;
            _queryStringParams = queryStringParams;
            _cookies = cookies;
            _url = new Uri(MvcTestContext.Url);
            _requestContext = new RequestContext(httpContext, routeData);//
        }
        public override NameValueCollection Form
        {
            get
            {
                return _formParams;
            }
        }
        public override NameValueCollection QueryString
        {
            get
            {
                return _queryStringParams;
            }
        }
        public override HttpCookieCollection Cookies
        {
            get
            {
                return _cookies;
            } 
        }
        public override Uri Url
        {
            get
            {
                return _url;
            }
        }
        public override RequestContext RequestContext
        {
            get
            {
                return _requestContext;
            } 
        }
        public override string this[string key]
        {
            get
            {
                string val = "";

                /*form*/
                foreach (var item in _formParams.AllKeys)
                {
                    if (key == item)
                        val = val + _formParams[item] + ",";
                }

                /*queryString*/
                foreach (var item in _queryStringParams.AllKeys)
                {
                    if (key == item)
                        val = val + _formParams[item] + ",";
                }

                /*cookies*/
                foreach (var item in _cookies.AllKeys)
                {
                    if (key == item)
                        val = val + _formParams[item] + ",";
                }

                if (val.Length == 0) 
                {
                    return null;
                }
                return val.Substring(0, val.Length-1);
            }
        }
    }
}
