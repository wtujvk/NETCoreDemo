using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace learning.common.tests.utils.FaKe
{
    public class FakeHttpApplication : HttpApplication
    {
        public virtual void Application_Start() { }
        public virtual void Session_End() { }
        public virtual void Application_Error(object sender, EventArgs e) { }
    }
}
