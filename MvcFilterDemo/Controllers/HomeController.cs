using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFilterDemo.Filters;

namespace MvcFilterDemo.Controllers
{
    [MyOwnManyFilter]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (!string.IsNullOrWhiteSpace(Request["e"]?.Trim()))
            {
                // throw new ArgumentException($"异常消息：{Request["e"]}");
                var a = 0;
                var t = a / a;
            }

            return View();
        }
    }
}