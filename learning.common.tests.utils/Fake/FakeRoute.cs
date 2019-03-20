using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace learning.common.tests.utils.FaKe
{
    class FakeRoute : RouteBase
    {

        public override RouteData GetRouteData(System.Web.HttpContextBase httpContext)
        {
            throw new NotImplementedException();
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            throw new NotImplementedException();
        }
    }
}
