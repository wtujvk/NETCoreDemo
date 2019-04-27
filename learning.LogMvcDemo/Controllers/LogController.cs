using learning.LogMvcDemo.Codes;
using learning.LogMvcDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace learning.LogMvcDemo.Controllers
{
    public class LogController : Controller
    {
        private string key;

        // GET: Log
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Post
        /// </summary>
        public ActionResult Post(LogInfo logInfo)
        {
            LogLogic logic = new LogLogic();
            if (!ModelState.IsValid)
            {
                //return badre(ModelState);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest,"参数不合法");
            }

            //检查安全密钥
            if (!logic.CheckKeyIsIsValid(logInfo))
            {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "安全密钥不匹配，请检查安全密钥！");
            }

            #region 设置颜色

            var color = "#FFFF33";
            switch (logInfo.Level)
            {
                case "Error":
                    color = "#FF3030";
                    break;
                case "Warn":
                    color = "#FFC125";
                    break;
                case "Debug":
                    color = "#FAEBD7";
                    break;
                case "Info":
                    color = "#FCFCFC";
                    break;
                case "Trace":
                    color = "#3CB371";
                    break;
                default:
                    break;
            }

            #endregion

            var data = new LogAttachment()
            {
                Title = HttpUtility.UrlDecode(logInfo.Title),
                Text = HttpUtility.UrlDecode(logInfo.Message),
                Pretext = logInfo.Level,
                Color = color,
                Fallback = logInfo.Title
            };
        
          return Json(Log(data));
        }

        /// <summary>
        /// lesschat日志频道Incoming WebHook地址
        /// </summary>
        static string url = System.Web.Configuration.WebConfigurationManager.AppSettings["hoot.lesschat"];

        private static string Log(LogAttachment data)
        {
            string json = JsonConvert.SerializeObject(data);
            var bytesToPost = System.Text.Encoding.UTF8.GetBytes(json);
            var wc = new WebClient();
            //Content-Type设置为application/json
            wc.Headers.Add("Content-Type", "application/json");
            var responseBytes = wc.UploadData(url, "POST", bytesToPost);
            var responseText = System.Text.Encoding.UTF8.GetString(responseBytes);
            return responseText;
        }
    }
}