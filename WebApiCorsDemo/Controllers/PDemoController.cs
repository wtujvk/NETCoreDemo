using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using NLog;
using WebApiCorsDemo.Codes;
using WebApiCorsDemo.Models;
using WebApiCorsDemo.Utility;

namespace WebApiCorsDemo.Controllers
{
    /// <summary>
    /// 示例。
    /// </summary>
    [AccessKey]
    [EnableCors("*", "*", "*")]
    public class PDemoController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        const string TempDir = "upload"; //文件目录

        /// <summary>
        /// [upload] 上传文件
        /// </summary>
        /// <remarks>[upload] 上传文件</remarks>
        /// <returns></returns>
        [HttpPost]
        [UploadMark("上传文件1", false)]
        public Object Upload()
        {
            var files = HttpContext.Current.Request.Files;
            var saveList = new List<string>();
            if (files != null)
            {
                var dirname = "upload";
                var dir = HttpContext.Current.Server.MapPath("~/" + dirname);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                for (int i = 0; i < files.Count; i++)
                {
                    var file0 = files[i];
                    var ext = Path.GetExtension(file0.FileName);
                    var fileName = Guid.NewGuid().ToString("N") + ext;
                    try
                    {
                        var savepath = string.Format("/{0}/{1}", dirname, fileName);
                        var localPath = HttpContext.Current.Server.MapPath(savepath);
                        file0.SaveAs(localPath);
                        saveList.Add(savepath);
                    }
                    catch (Exception ex)
                    {
                        // Logger.Error(ex);
                    }
                }
            }
            return Json(saveList);
        }

        /// <summary>
        ///上传文件
        /// </summary>
        /// <remarks>[upload] 上传文件</remarks>
        /// <param name="parameter">携带的参数</param>
        /// <returns></returns>
        [HttpPost, Route("upload2")]
        [UploadMark("上传文件演示", true)]
        public async Task<AjaxData> UploadFileAsync(string parameter = "")
        {
            AjaxData<IEnumerable<string>> ajaxData = AjaxData.GetAjaxData<IEnumerable<string>>();
            try
            {
                var files = HttpContext.Current.Request.Files;
                return await UploadFileMethodAsync(files, parameter);
            }
            catch (Exception ex)
            {
                ajaxData.Msg = $"{ex.Message}-{ex.StackTrace}";
            }
            return ajaxData;
        }

        /// <summary>
        /// 文件上传方法
        /// </summary>
        /// <returns></returns>
        [NonAction]
        private async Task<AjaxData> UploadFileMethodAsync(HttpFileCollection files, string msg)
        {
            AjaxData<IEnumerable<string>> ajaxData = AjaxData.GetAjaxData<IEnumerable<string>>();
            try
            {
                var savepaths = new List<string>();//保存的文件名集合
                if (files != null && files.Count > 0)
                {
                    var physicdir = HttpContext.Current.Server.MapPath(string.Format("~/{0}", TempDir));
                    if (!System.IO.Directory.Exists(physicdir))
                    {
                        Directory.CreateDirectory(physicdir);
                    }
                    foreach (var key0 in files.AllKeys)
                    {
                        if (string.IsNullOrWhiteSpace(key0)) continue;
                        var itemfile = files[key0];
                        var filename = string.Format("{0}{1}", Guid.NewGuid().ToString("N"), Path.GetExtension(itemfile.FileName)); //文件名
                        var virpath = string.Format("/{0}/{1}", TempDir, filename); //保存的文件虚拟目录
                        var physicpath = Path.Combine(physicdir, filename);//保存的文件物理路径
                        using (var stream = System.IO.File.Open(physicpath, FileMode.Create))
                        {
                            await itemfile.InputStream.CopyToAsync(stream);
                        }
                        savepaths.Add(virpath);
                    }
                    ajaxData.Res = savepaths;
                    ajaxData.OK = true;
                    ajaxData.Msg = msg;
                }
                else
                {
                    ajaxData.Msg = "没有接收到文件";
                }
            }
            catch (Exception ex)
            {
                ajaxData.Msg = $"{ex.Message}-{ex.StackTrace}";
            }

            return ajaxData;
        }
    }
}
