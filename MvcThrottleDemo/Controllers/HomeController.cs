using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcThrottle;

namespace MvcThrottleDemo.Controllers
{
    [EnableThrottling]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return Content(DateTime.Now.ToString(CultureInfo.InvariantCulture));
        }

        [DisableThrottling]
        public ActionResult About()
        {
            return Content(DateTime.Now.ToString(CultureInfo.InvariantCulture));
        }

        [EnableThrottling(PerSecond = 2, PerMinute = 10, PerHour = 30, PerDay = 300)]
        public ActionResult Index2()
        {
            return Content(DateTime.Now.ToString(CultureInfo.InvariantCulture));
        }
    }
}