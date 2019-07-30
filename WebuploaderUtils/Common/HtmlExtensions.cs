using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebuploaderUtils.Common
{
    /// <summary>
    /// 一些html扩展
    /// </summary>
    public static class HtmlExtensions
    {
        #region url

        /// <summary>
        /// 获取actionName
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static string ActionName(this HtmlHelper htmlHelper)
        {
            var name = htmlHelper.ViewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();
            return name ?? string.Empty;
        }

        /// <summary>
        /// 获取controllerName
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static string ControllerName(this HtmlHelper htmlHelper)
        {
            var name = htmlHelper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
            return name ?? string.Empty;
        }

        /// <summary>
        /// 生成页面的Url
        /// </summary>
        /// <param name="param"></param>
        /// <param name="value"></param>
        /// <returns>navigated url for pager item</returns>
        public static string GenerateUrl(this HtmlHelper html, string param, string value)
        {
            var routeValues = new RouteValueDictionary(html.ViewContext.RouteData.Values);

            var rq = HttpContext.Current.Request.QueryString;
            if (rq != null && rq.Count > 0)
            {
                foreach (string key in rq.Keys)
                {
                    if (key != param && string.IsNullOrEmpty(rq[key]) == false && rq[key] != ",")
                    {
                        if (rq[key].IndexOf(",") > -1)
                        {
                            routeValues.AddArrayValue(rq[key].Split(','), key);
                        }
                        else
                        {
                            routeValues[key] = rq[key];
                        }
                    }
                }
            }

            routeValues[param] = value;
            // Add action
            //routeValues["action"] = html.ViewContext.RouteData.Values["action"];
            // Add controller
            //routeValues["controller"] = html.ViewContext.RouteData.Values["controller"];

            // Return link
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            //if (!string.IsNullOrEmpty(_routeName))
            //    return urlHelper.RouteUrl(_routeName, routeValues);
            return urlHelper.RouteUrl(routeValues);
        }

        /// <summary>
        /// 添加数组到路由数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="rv">路由数据</param>
        /// <param name="array">要添加的数组数据</param>
        /// <param name="arrayName">路由中的名称</param>
        /// <returns></returns>
        public static RouteValueDictionary AddArrayValue<T>(this RouteValueDictionary rv, T[] array, string arrayName)
        {
            if (array != null && array.Length != 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    rv.Add(string.Format("{0}[{1}]", arrayName, i), array[i]);
                }
            }
            else
            {
                rv.Add(arrayName, null);
            }

            return rv;
        }

        #endregion

        #region 截取字符串

        /// <summary>
        /// 裁切字符串（中文按照两个字符计算）
        /// </summary>
        /// <param name="str">旧字符串</param>
        /// <param name="len">新字符串长度</param>
        /// <param name="HtmlEnable">为 false 时过滤 Html 标签后再进行裁切，反之则保留 Html 标签。</param>
        /// <remarks>
        /// <para>注意：<ol>
        /// <li>若字符串被截断则会在末尾追加“...”，反之则直接返回原始字符串。</li>
        /// <li>参数 <paramref name="HtmlEnable"/> 为 false 时会先调用<see cref="uoLib.Common.Functions.HtmlFilter"/>过滤掉 Html 标签再进行裁切。</li>
        /// <li>中文按照两个字符计算。若指定长度位置恰好只获取半个中文字符，则会将其补全，如下面的例子：<br/>
        /// <code><![CDATA[
        /// string str = "感谢使用uoLib。";
        /// string A = CutStr(str,4);   // A = "感谢..."
        /// string B = CutStr(str,5);   // B = "感谢使..."
        /// ]]></code></li>
        /// </ol>
        /// </para>
        /// </remarks>
        public static string CutStr(this HtmlHelper html, string str, int len, bool HtmlEnable)
        {
            if (str == null || str.Length == 0 || len <= 0)
            {
                return string.Empty;
            }

            if (HtmlEnable == false)
            {
                str = HtmlFilter(str);
            }

            int l = str.Length;

            #region 计算长度

            int clen = 0; //当前长度
            while (clen < len && clen < l)
            {
                //每遇到一个中文，则将目标长度减一。
                if ((int) str[clen] > 128)
                {
                    len--;
                }

                clen++;
            }

            #endregion

            if (clen < l)
            {
                return str.Substring(0, clen) + "...";
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// 裁切字符串（中文按照两个字符计算，裁切前会先过滤 Html 标签）
        /// </summary>
        /// <param name="str">旧字符串</param>
        /// <param name="len">新字符串长度</param>
        /// <remarks>
        /// <para>注意：<ol>
        /// <li>若字符串被截断则会在末尾追加“...”，反之则直接返回原始字符串。</li>
        /// <li>中文按照两个字符计算。若指定长度位置恰好只获取半个中文字符，则会将其补全，如下面的例子：<br/>
        /// <code><![CDATA[
        /// string str = "感谢使用uoLib模块。";
        /// string A = CutStr(str,4);   // A = "感谢..."
        /// string B = CutStr(str,5);   // B = "感谢使..."
        /// ]]></code></li>
        /// </ol>
        /// </para>
        /// </remarks>
        public static string CutStr(this HtmlHelper html, string str, int len)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            else
            {
                return CutStr(html, str, len, false);
            }
        }

        /// <summary>
        /// 获取字符串长度。与string.Length不同的是，该方法将中文作 2 个字符计算。
        /// </summary>
        /// <param name="str">目标字符串</param>
        /// <returns></returns>
        private static int GetLength(string str)
        {
            if (str == null || str.Length == 0)
            {
                return 0;
            }

            int l = str.Length;
            int realLen = l;

            #region 计算长度

            int clen = 0; //当前长度
            while (clen < l)
            {
                //每遇到一个中文，则将实际长度加一。
                if ((int) str[clen] > 128)
                {
                    realLen++;
                }

                clen++;
            }

            #endregion

            return realLen;
        }

        /// <summary>
        /// 过滤HTML标签
        /// </summary>
        private static string HtmlFilter(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            else
            {
                Regex re = new Regex("<\\/*[^<>]*>", RegexOptions.IgnoreCase);
                return re.Replace(str, "");
            }
        }

        #endregion

        #region 截取html

        /// <summary>
        /// 按字节长度截取字符串(支持截取带HTML代码样式的字符串)
        /// </summary>
        /// <param name="param">将要截取的字符串参数</param>
        /// <param name="length">截取的字节长度</param>
        /// <param name="end">字符串末尾补上的字符串</param>
        /// <returns>返回截取后的字符串</returns>
        public static string SubstringToHTML(string param, int length, string end)
        {
            if (string.IsNullOrEmpty(param) == true)
            {
                return string.Empty;
            }

            string Pattern = null;
            MatchCollection m = null;
            StringBuilder result = new StringBuilder();
            int n = 0;
            char temp;
            bool isCode = false; //是不是HTML代码
            bool isHTML = false; //是不是HTML特殊字符,如&nbsp;
            char[] pchar = param.ToCharArray();
            for (int i = 0; i < pchar.Length; i++)
            {
                temp = pchar[i];
                if (temp == '<')
                {
                    isCode = true;
                }
                else if (temp == '&')
                {
                    isHTML = true;
                }
                else if (temp == '>' && isCode)
                {
                    n = n - 1;
                    isCode = false;
                }
                else if (temp == ';' && isHTML)
                {
                    isHTML = false;
                }

                if (!isCode && !isHTML)
                {
                    n = n + 1;
                    //UNICODE码字符占两个字节
                    if (System.Text.Encoding.Default.GetBytes(temp + "").Length > 1)
                    {
                        n = n + 1;
                    }
                }

                result.Append(temp);
                if (n >= length)
                {
                    break;
                }
            }

            result.Append(end);
            //取出截取字符串中的HTML标记
            string temp_result = result.ToString().Replace("(>)[^<>]*(<?)", "$1$2");
            //去掉不需要结素标记的HTML标记
            temp_result = temp_result.Replace(
                @"</?(AREA|BASE|BASEFONT|BODY|BR|COL|COLGROUP|DD|DT|FRAME|HEAD|HR|HTML|IMG|INPUT|ISINDEX|LI|LINK|META|OPTION|P|PARAM|TBODY|TD|TFOOT|TH|THEAD|TR|area|base|basefont|body|br|col|colgroup|dd|dt|frame|head|hr|html|img|input|isindex|li|link|meta|option|p|param|tbody|td|tfoot|th|thead|tr)[^<>]*/?>",
                "");
            //去掉成对的HTML标记
            temp_result = temp_result.Replace(@"<([a-zA-Z]+)[^<>]*>(.*?)</\1>", "$2");
            //用正则表达式取出标记
            Pattern = ("<([a-zA-Z]+)[^<>]*>");
            m = Regex.Matches(temp_result, Pattern);

            ArrayList endHTML = new ArrayList();

            foreach (Match mt in m)
            {
                endHTML.Add(mt.Result("$1"));
            }

            //补全不成对的HTML标记
            for (int i = endHTML.Count - 1; i >= 0; i--)
            {
                result.Append("</");
                result.Append(endHTML[i]);
                result.Append(">");
            }

            return result.ToString();
        }

        /// <summary>
        /// 计算有多少个中文字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static int CountChineseWord(String str)
        {
            int n = 0, i = 0;
            if (string.IsNullOrEmpty(str))
            {
                n = 0;
            }
            else
            {
                for (i = 0; i < str.Length; i++)
                {
                    byte[] b = Encoding.Default.GetBytes(str.Substring(i, 1));
                    if (b.Length > 1)
                    {
                        n = n + 1;
                    }
                }
            }

            return n;
        }

        #endregion

        #region FileName

        //文件小图标
        public static MvcHtmlString FileIcon(this HtmlHelper htmlHelper, string filePath, bool isImagesThumb = true,
            bool isLink = true, int imgWidth = 100, int imgHeight = 100)
        {
            return MvcHtmlString.Create(filePath.FileIcon(isImagesThumb, isLink, imgWidth, imgHeight));

            /*
            string fileName = System.IO.Path.GetFileName(filePath);
            string fileExt = System.IO.Path.GetExtension(filePath).Substring(1).ToLower();
            bool isImage = ("bmp,jpg,jpeg,tiff,gif,pcx,tga,exif,fpx,svg,psd,cdr,pcd,dxf,ufo,eps,ai,raw".IndexOf(fileExt) > -1);

            string iconPath = "~/Assets/ueditor/dialogs/attachment/fileTypeImages/icon_{0}.gif";

            #region 文件图标
            switch (fileExt)
            {
                case "chm":
                case "exe":
                case "jpg":
                case "mp3":
                case "mv":
                case "pdf":
                case "psd":
                case "rar":
                case "txt":
                    iconPath = string.Format(iconPath, fileExt);
                    break;
                case "ppt":
                case "pptx":
                    iconPath = string.Format(iconPath, "ppt");
                    break;
                case "doc":
                case "docx":
                    iconPath = string.Format(iconPath, "doc");
                    break;
                case "xls":
                case "xlsx":
                    iconPath = string.Format(iconPath, "xls");
                    break;
                default:
                    iconPath = string.Format(iconPath, "txt");
                    break;
            }
            #endregion

            var Url = (new UrlHelper(htmlHelper.ViewContext.RequestContext));

            string _file_path = Url.Content(filePath);
            StringBuilder _sb = new StringBuilder();
            if (isLink == true)
            {
                _sb.Append(string.Format("<a href=\"0\" target=\"_blank\">", _file_path));
            }
            string image = string.Format("<img style=\"width:{1}px;height:{2}px;\" src=\"{0}\"/>", _file_path, imgWidth, imgHeight);
            string icon = string.Format("<img src=\"{0}\" />", Url.Content(iconPath));

            _sb.Append(string.Format("{0}<span class=\"f-sp-name\">&nbsp;{1}</span>", (isImagesThumb == true && isImage == true) ? image : icon, fileName));

            if (isLink == true)
            {
                _sb.Append("</a>");
            }

            return MvcHtmlString.Create(_sb.ToString());
            */
        }

        public static string FileIcon(this string filePath, bool isImagesThumb = true, bool isLink = true,
            int imgWidth = 100, int imgHeight = 100)
        {
            if (string.IsNullOrEmpty(filePath) == true)
            {
                return string.Empty;
            }

            string fileName = System.IO.Path.GetFileName(filePath);
            string fileExt = System.IO.Path.GetExtension(filePath).Substring(1).ToLower();
            bool isImage =
                ("bmp,jpg,jpeg,png,tiff,gif,pcx,tga,exif,fpx,svg,psd,cdr,pcd,dxf,ufo,eps,ai,raw".IndexOf(fileExt) > -1);

            string iconPath = "~/Assets/ueditor/dialogs/attachment/fileTypeImages/icon_{0}.gif";

            #region 文件图标

            switch (fileExt)
            {
                case "chm":
                case "exe":
                case "jpg":
                case "mp3":
                case "mv":
                case "pdf":
                case "psd":
                case "rar":
                case "txt":
                    iconPath = string.Format(iconPath, fileExt);
                    break;
                case "ppt":
                case "pptx":
                    iconPath = string.Format(iconPath, "ppt");
                    break;
                case "doc":
                case "docx":
                    iconPath = string.Format(iconPath, "doc");
                    break;
                case "xls":
                case "xlsx":
                    iconPath = string.Format(iconPath, "xls");
                    break;
                default:
                    iconPath = string.Format(iconPath, "txt");
                    break;
            }

            #endregion

            var Url = (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext));

            string _file_path = Url.Content(filePath);

            StringBuilder _sb = new StringBuilder();

            if (isLink == true)
            {
                _sb.Append(string.Format("<a href=\"{0}\" target=\"_blank\">", _file_path));
            }

            string image = string.Format("<img style=\"width:{1}px;height:{2}px;\" src=\"{0}\"/>", _file_path, imgWidth,
                imgHeight);
            string icon = string.Format("<img src=\"{0}\" />", Url.Content(iconPath));

            _sb.Append(string.Format("{0}<span class=\"f-sp-name\">&nbsp;{1}</span>",
                (isImagesThumb == true && isImage == true) ? image : icon, fileName));

            if (isLink == true)
            {
                _sb.Append("</a>");
            }

            return _sb.ToString();
        }

        #endregion
    }

    /// <summary>
    /// 一些常量
    /// </summary>
    public class SystemConst
    {
        public const string MIME_DOC = "application/msword";
        public const string MIME_DOCX = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        public const string MIME_XLS = "application/vnd.ms-excel";
        public const string MIME_XLSX = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public const string MIME_PDF = "application/pdf";
        public const string MIME_PPT = "application/vnd.ms-powerpoint";

        public const string MIME_RAR = "application/x-rar-compressed";
        public const string MIME_ZIP = "application/x-zip-compressed";

        public const string MIME_CSS = "text/css";
        public const string MIME_HTML = "text/html";
        public const string MIME_JS = "application/x-javascript";
        public const string MIME_JSON = "application/json";
        public const string MIME_TXT = "text/plain";

        public const string MIME_JPG = "image/jpeg";
        public const string MIME_GIF = "image/gif";
        public const string MIME_PNG = "image/png";

        public const string AJAX_CALLBACK = "ajaxCallback";
    }

    /// <summary>
    /// ajax请求返回的json数据
    /// </summary>
    public class AjaxJsonResult
    {
        /// <summary>
        /// ajax请求返回的数据
        /// <para>msg:非空,提示信息</para>
        /// <para>cnt:可空,辅助调试信息</para>
        /// <para>url:可空,操作成功或失败后的跳转地址</para>
        /// <para>timeout:默认3(秒),信息弹出停留时间</para>
        /// </summary>
        public AjaxJsonResult()
        {
            this.err = true;
            this.code = 10000;
            this.msg = string.Empty;
            this.cnt = string.Empty;
            this.url = string.Empty;
            this.timeout = 3F;
        }

        /// <summary>
        /// 是否错误
        /// </summary>
        public bool err { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 错误或成功的消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 附加的内容
        /// </summary>
        public string cnt { get; set; }

        /// <summary>
        /// 要跳转的地址(不跳转则留空)
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 要移除的dom
        /// <para>#id or .class</para>
        /// </summary>
        public string delid { get; set; }

        /// <summary>
        /// 提示信息停了的时间(默认1.5s)
        /// </summary>
        public float timeout { get; set; }
    }
}