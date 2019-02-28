using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiThrottle;

namespace WebApiThrottleDemo.Controllers
{
    public class HomeController : ApiController
    {
        [EnableThrottling(PerSecond = 2)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", DateTime.Now.ToString(CultureInfo.InvariantCulture) };
        }

        [DisableThrotting]
        public string Get(int id)
        {
            return id+DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }       
    }
}
