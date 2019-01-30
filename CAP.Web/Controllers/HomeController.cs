using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAP.Web.Codes;

namespace CAP.Web.Controllers
{
    /// <summary>
    /// 首页。
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// 发布服务接口。
        /// </summary>
        private readonly ICapPublisher _capBus;

        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="capPublisher">发布服务接口。</param>
        public HomeController(ICapPublisher capPublisher)
        {
            _capBus = capPublisher;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 发布消息。
        /// </summary>
        /// <param name="message">消息。</param>
        /// <returns>操作的结果。</returns>
        public ActionResult Publish(string message)
        {
            AjaxDataResult<string> ajaxDataResult = AjaxDataResult<string>.GetDataResult();
            try
            {
                _capBus.Publish(AppDataInit.MQRouteKey, message);
                ajaxDataResult.Msg = "OK";
                ajaxDataResult.Ok = true;
                ajaxDataResult.Msg = message;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ajaxDataResult.Msg = ex.Message;
            }

            return Json(ajaxDataResult);
        }

        [NonAction]
        [CapSubscribe(AppDataInit.MQRouteKey)]
        public void CheckReceivedMessage(string message)
        {
            Console.WriteLine(message);
            logger.Debug(message);
        }

        [NonAction]
        [CapSubscribe(AppDataInit.MQRouteKey)]
        public void CheckReceivedMessage2(MessageBody messageBody)
        {
            Console.WriteLine(messageBody.Name);
            Console.WriteLine(messageBody.CreateTime);
            logger.Debug(messageBody);
        }
    }
}