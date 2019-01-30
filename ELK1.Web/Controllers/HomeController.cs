using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ELK1.Web.Controllers
{
    public class HomeController : Controller
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 输出日志。
        /// </summary>
        /// <param name="message">消息。</param>
        /// <param name="type">类别。</param>
        /// <returns></returns>
        public ActionResult Log(string message, int type = 1)
        {
            switch (type)
            {
                case 1:
                    logger.Trace(message);
                    break;
                case 2:
                    logger.Debug(message);
                    break;
                case 3:
                    logger.Info(message);
                    break;
                case 4:
                    logger.Warn(message);
                    break;
                case 5:
                    logger.Error(message);
                    break;
                case 6:
                    logger.Fatal(message);
                    break;
                default:
                    break;
            }

            return Json(new { ok = 1, type });
        }
    }
}
