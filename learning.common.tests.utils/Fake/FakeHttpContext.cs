using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Web.SessionState;
using System.Security.Principal;
using System.Web.Routing;
using System.Collections;

namespace learning.common.tests.utils.FaKe
{
    public class FakeHttpContext : HttpContextBase
    {
        private readonly FakePrincipal _principal;
        private readonly NameValueCollection _formParams;
        private readonly NameValueCollection _queryStringParams;
        private readonly HttpCookieCollection _cookies;
        private readonly SessionStateItemCollection _sessionItems;
        private readonly HttpResponseBase _response;
        private readonly FakeHttpRequest _request;
        private readonly FakeDictionary _items;

        public FakeHttpContext(FakePrincipal principal, NameValueCollection formParams, NameValueCollection queryStringParams, HttpCookieCollection cookies, SessionStateItemCollection sessionItems,RouteData routeData)
        {
            _principal = principal;
            _formParams = formParams;
            _queryStringParams = queryStringParams;
            _cookies = cookies;
            _sessionItems = sessionItems;
            _response = new FakeHttpResponse();
            _request = new FakeHttpRequest(_formParams, _queryStringParams, _cookies,this,routeData);
            _items = new FakeDictionary();
        }

        public override HttpRequestBase Request
        {
            get
            {
                return _request;
            }
        }

        public override IPrincipal User
        {
            get
            {
                return _principal;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public override HttpSessionStateBase Session
        {
            get
            {
                return new FakeHttpSessionState(_sessionItems);
            }
        }

        public override HttpResponseBase Response
        {
            get
            {
                return _response;
            }
        } 
        public override IDictionary Items
        {
            get
            {
                return _items;
            }
        }
    }
}
