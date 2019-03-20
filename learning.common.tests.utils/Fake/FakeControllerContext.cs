using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.Web.SessionState;
using System.Collections.Specialized;
using System.Web.Routing;

namespace learning.common.tests.utils.FaKe
{
    public class FakeControllerContext : ControllerContext
    { 
        public FakeControllerContext(FakeHttpContext fakeHttpContext, RouteData routeData, ControllerBase controller)
            : base(fakeHttpContext, routeData, controller)
        { }
    }
}