using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebuploaderUtils.Common
{
    /// <summary>
    /// 上传文件帮助类
    /// </summary> 
    public class UploadFilesHelper
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileType">0文件,1图片,2视频</param>
        public UploadFilesHelper(UploadFileType fileType = UploadFileType.File)
        {
            this.UploadConfig = new UploadConfig
            {
                Base64 = false,
                Base64Filename = "",
                SizeLimit = 2097152,
                UploadFieldName = "upfile"
            };

            switch (fileType)
            {
                case UploadFileType.Image:
                    this.UploadConfig.AllowExtensions = new string[] {".png", ".jpg", ".jpeg", ".gif", ".bmp"};
                    this.UploadConfig.PathFormat = "/assets/userfiles/images/Net/usertemp/{time}";
                    this.UploadConfig.SizeLimit = 2097152; //2M
                    break;
                case UploadFileType.Video:
                    this.UploadConfig.AllowExtensions = new string[]
                    {
                        ".flv", ".swf", ".mkv", ".avi", ".rm", ".rmvb", ".mpeg", ".mpg", ".ogg", ".ogv", ".mov", ".wmv",
                        ".mp4", ".webm", ".mp3", ".wav", ".mid"
                    };
                    this.UploadConfig.PathFormat = "/assets/userfiles/Files/Net/usertemp/Video/{time}";
                    this.UploadConfig.SizeLimit = 41943040; //40M
                    break;
                case UploadFileType.File:
                default:
                    this.UploadConfig.AllowExtensions = new string[]
                    {
                        ".png", ".jpg", ".jpeg", ".gif", ".bmp",
                        ".flv", ".swf", ".mkv", ".avi", ".rm", ".rmvb", ".mpeg", ".mpg",
                        ".ogg", ".ogv", ".mov", ".wmv", ".mp4", ".webm", ".mp3", ".wav", ".mid",
                        ".rar", ".zip", ".tar", ".gz", ".7z", ".bz2", ".cab", ".iso",
                        ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".pdf", ".txt", ".md", ".xml"
                    };
                    this.UploadConfig.PathFormat = "/assets/userfiles/files/Net/usertemp/Files/{time}";
                    this.UploadConfig.SizeLimit = 20971520; //40M
                    break;
            }
        }

        /// <summary>
        /// 上传文件配置
        /// </summary>
        public UploadConfig UploadConfig { get; set; }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public UploadResult UploadFile(string uploadFieldName, string uname)
        {
            if (string.IsNullOrEmpty(uploadFieldName) == false)
            {
                UploadConfig.UploadFieldName = uploadFieldName;
            }

            if (string.IsNullOrEmpty(uname) == false)
            {
                UploadConfig.PathFormat = UploadConfig.PathFormat.Replace("usertemp", uname);
            }

            var Request = System.Web.HttpContext.Current.Request;
            var Result = new UploadResult();

            byte[] uploadFileBytes = null;
            string uploadFileName = null;

            if (UploadConfig.Base64)
            {
                uploadFileName = UploadConfig.Base64Filename;
                uploadFileBytes = Convert.FromBase64String(Request[UploadConfig.UploadFieldName]);
            }
            else
            {
                var file = Request.Files[UploadConfig.UploadFieldName];
                uploadFileName = file.FileName;

                if (CheckFileType(uploadFileName) == false)
                {
                    Result.State = UploadState.TypeNotAllow;
                    return Result;
                }

                if (CheckFileSize(file.ContentLength) == false)
                {
                    Result.State = UploadState.SizeLimitExceed;
                    return Result;
                }

                uploadFileBytes = new byte[file.ContentLength];
                try
                {
                    file.InputStream.Read(uploadFileBytes, 0, file.ContentLength);
                    Result.FileSize = file.ContentLength;
                    Result.ContentType = file.ContentType;
                }
                catch (Exception)
                {
                    Result.State = UploadState.NetworkError;
                    return Result;
                }
            }

            Result.OriginFileName = uploadFileName;

            var savePath = PathFormatter.Format(uploadFileName, UploadConfig.PathFormat);
            var localPath = System.Web.HttpContext.Current.Server.MapPath(savePath);
            try
            {
                if (Directory.Exists(Path.GetDirectoryName(localPath)) == false)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(localPath));
                }

                File.WriteAllBytes(localPath, uploadFileBytes);
                Result.Url = savePath;
                Result.State = UploadState.Success;
            }
            catch (Exception e)
            {
                Result.State = UploadState.FileAccessError;
                Result.ErrorMessage = e.Message;
            }
            finally
            {
            }

            return Result;
        }

        /// <summary>
        /// 检查文件类型
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private bool CheckFileType(string filename)
        {
            var fileExtension = Path.GetExtension(filename).ToLower();
            return UploadConfig.AllowExtensions.Select(x => x.ToLower()).Contains(fileExtension);
        }

        /// <summary>
        /// 检查文件大小
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private bool CheckFileSize(int size)
        {
            return size < UploadConfig.SizeLimit;
        }

        /// <summary>
        /// 生成 (年,月,日,时,分,秒)+随机数的文件名。
        /// </summary>
        /// <returns></returns>
        private string RandomName()
        {
            Random rm = new Random(System.Environment.TickCount);
            return System.DateTime.Now.ToString("yyyyMMddHHmmss_") + rm.Next(1000, 9999).ToString();
        }

        /// <summary>
        /// 文件扩展名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetExtName(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf(".") + 1);
        }
    }

    /// <summary>
    /// 上传文件配置
    /// </summary>
    public class UploadConfig
    {
        /// <summary>
        /// 文件命名规则
        /// </summary>
        public string PathFormat { get; set; }

        /// <summary>
        /// 上传表单域名称
        /// </summary>
        public string UploadFieldName { get; set; }

        /// <summary>
        /// 上传大小限制(注意要修改web.config)
        /// </summary>
        public int SizeLimit { get; set; }

        /// <summary>
        /// 上传允许的文件格式
        /// </summary>
        public string[] AllowExtensions { get; set; }

        /// <summary>
        /// 文件是否以 Base64 的形式上传
        /// </summary>
        public bool Base64 { get; set; }

        /// <summary>
        /// Base64 字符串所表示的文件名
        /// </summary>
        public string Base64Filename { get; set; }
    }

    /// <summary>
    /// 文件上传返回Model
    /// </summary>
    public class UploadResult
    {
        /// <summary>
        /// 文件上传状态(枚举)
        /// </summary>
        public UploadState State { get; set; }

        /// <summary>
        /// 文件上传状态(字符串)
        /// </summary>
        public string StateStr
        {
            get { return this.GetStateMessage(this.State); }
        }

        /// <summary>
        /// 文件上传后的路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 原始文件名
        /// </summary>
        public string OriginFileName { get; set; }

        /// <summary>
        /// 文件的 MIME 内容类型
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public int FileSize { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

        private string GetStateMessage(UploadState state)
        {
            switch (state)
            {
                case UploadState.Success:
                    return "SUCCESS";
                case UploadState.FileAccessError:
                    return "文件访问出错，请检查写入权限";
                case UploadState.SizeLimitExceed:
                    return "文件大小超出服务器限制";
                case UploadState.TypeNotAllow:
                    return "不允许的文件格式";
                case UploadState.NetworkError:
                    return "网络错误";
            }

            return "未知错误";
        }
    }

    /// <summary>
    /// 上传的文件类型
    /// </summary>
    public enum UploadFileType
    {
        File = 0,
        Image = 1,
        Video = 2
    }

    /// <summary>
    /// 文件上传状态
    /// </summary>
    public enum UploadState
    {
        Success = 0,
        SizeLimitExceed = -1,
        TypeNotAllow = -2,
        FileAccessError = -3,
        NetworkError = -4,
        Unknown = 1,
    }

    /// <summary>
    /// PathFormater 的摘要说明
    /// </summary>
    public static class PathFormatter
    {
        public static string Format(string originFileName, string pathFormat)
        {
            if (String.IsNullOrWhiteSpace(pathFormat))
            {
                pathFormat = "{filename}{rand:6}";
            }

            var invalidPattern = new Regex(@"[\\\/\:\*\?\042\<\>\|]");
            originFileName = invalidPattern.Replace(originFileName, "");

            string extension = Path.GetExtension(originFileName);
            string filename = Path.GetFileNameWithoutExtension(originFileName);

            pathFormat = pathFormat.Replace("{filename}", filename);
            pathFormat = new Regex(@"\{rand(\:?)(\d+)\}", RegexOptions.Compiled).Replace(pathFormat,
                new MatchEvaluator(delegate(Match match)
                {
                    var digit = 6;
                    if (match.Groups.Count > 2)
                    {
                        digit = Convert.ToInt32(match.Groups[2].Value);
                    }

                    var rand = new Random();
                    return rand.Next((int) Math.Pow(10, digit), (int) Math.Pow(10, digit + 1)).ToString();
                }));

            pathFormat = pathFormat.Replace("{time}", DateTime.Now.ToString("ddHHssmmffff"));
            //pathFormat = pathFormat.Replace("{yyyy}", DateTime.Now.Year.ToString());
            //pathFormat = pathFormat.Replace("{yy}", (DateTime.Now.Year % 100).ToString("D2"));
            //pathFormat = pathFormat.Replace("{mm}", DateTime.Now.Month.ToString("D2"));
            //pathFormat = pathFormat.Replace("{dd}", DateTime.Now.Day.ToString("D2"));
            //pathFormat = pathFormat.Replace("{hh}", DateTime.Now.Hour.ToString("D2"));
            //pathFormat = pathFormat.Replace("{ii}", DateTime.Now.Minute.ToString("D2"));
            //pathFormat = pathFormat.Replace("{ss}", DateTime.Now.Second.ToString("D2"));
            //pathFormat = pathFormat.Replace("{origin}", originFileName);

            return pathFormat + extension;
        }
    }
}