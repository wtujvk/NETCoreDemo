using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebuploaderUtils.Common;

namespace WebuploaderMvcDemo.Controllers
{
    public class ServerController : Controller
    {
        // GET: Server
        [HttpPost]
        public virtual JsonResult FileUpload(long? timespan, string token, int fileType, string pathFormat, int sizeLimit)
        {
            var fileUpload = new UploadFilesHelper((UploadFileType) fileType) {UploadConfig = {SizeLimit = sizeLimit}};
            if (pathFormat.IsNullOrEmpty() == false)
            {
                fileUpload.UploadConfig.PathFormat = pathFormat;
            }

            var uploadResult = fileUpload.UploadFile("file", Guid.NewGuid().ToString());
            return Json(uploadResult);
        }

        /// <summary>
        /// 删除文件。
        /// </summary>
        /// <param name="file">文件地址。</param>
        /// <param name="cid">文件id。</param>
        /// <returns></returns>
        [HttpPost]
        public virtual JsonResult DeleteFile(string file, string cid)
        {
            var err = true;
            var msg = string.Empty;
            if (string.IsNullOrEmpty(file) == true)
            {
                msg = "File does not exist";
            }
            else
            {
                try
                {
                    System.IO.File.Delete(Server.MapPath(file));
                    err = false;
                }
                catch (Exception ex)
                {
                    msg = "Error";
                }
            }

            return Json(new { err = err, msg = msg });
        }
    }
}