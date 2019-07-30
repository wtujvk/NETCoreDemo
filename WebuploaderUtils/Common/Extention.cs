using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;
//using System.Web.Script.Serialization;
using WebuploaderUtils.Extensions;

namespace WebuploaderUtils.Common
{
    /// <summary>
    /// 扩展方法。
    /// </summary>
    public static class CommonExtension
    {
        public static bool NotLoad(this ViewContext viewContext, string key)
        {
            bool r = viewContext.Controller.ViewData.ContainsKey(key);

            if (r == false)
            {
                viewContext.Controller.ViewData[key] = true;
            }

            return r == false;
        }

        public static MvcHtmlString LoadPageCssJs(this UrlHelper url, bool css = true, bool js = true)
        {
            var r = url.RequestContext.RouteData;

            var area = r.DataTokens["area"].ToString();
            var controller = r.Values["controller"].ToString();
            var action = r.Values["action"].ToString();

            var sb = new StringBuilder();
            if (css)
            {
                sb.AppendLine(Css(url, string.Format("{0}/{1}/{2}.css", area, controller, action)).ToString());
            }

            if (js)
            {
                sb.AppendLine(Js(url, string.Format("{0}/{1}/{2}.js", area, controller, action)).ToString());
            }

            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString TreeViewResource(this UrlHelper url)
        {
            return Concat(url.LoadCss(ScriptBasePath, "zTree/zTreeStyle/zTreeStyle.css"),
                url.Js("zTree/jquery.ztree.all-3.5.min.js"));
        }

        public static MvcHtmlString Concat(this MvcHtmlString s, params MvcHtmlString[] other)
        {
            var sb = new StringBuilder(s.ToString());

            if (other != null && other.Length > 0)
            {
                other.Each(t => sb.AppendLine(t.ToString()));
            }

            return MvcHtmlString.Create(sb.ToString());
        }

        #region image

        public static string Image(this UrlHelper url, string filePath)
        {
            return url.Content("~/Assets/Images/" + filePath);
        }

        #endregion image

        #region css

        public static MvcHtmlString Css(this UrlHelper url, params string[] filePath)
        {
            return LoadCss(url, CssBasePath, filePath);
        }

        /// <summary>
        /// 加载js目录下面的css
        /// </summary>
        public static MvcHtmlString ScriptCss(this UrlHelper url, params string[] filePath)
        {
            return LoadCss(url, ScriptBasePath, filePath);
        }

        /// <summary>
        /// 加载Assets目录下面的css
        /// </summary>
        public static MvcHtmlString AssetsCss(this UrlHelper url, params string[] filePath)
        {
            return LoadCss(url, AssetsBasePath, filePath);
        }

        private static MvcHtmlString LoadCss(this UrlHelper url, string rootPath, params string[] filePath)
        {
            return LoadResource(url, "<link href='{0}' rel='stylesheet' type='text/css' />", rootPath, filePath);
        }

        #endregion css

        #region js

        public static MvcHtmlString JQueryBaseJs(this UrlHelper url, bool load = true)
        {
            return load ? Js(url, JQueryBasePath) : MvcHtmlString.Empty;
        }

        public static MvcHtmlString JQueryValidateJs(this UrlHelper url, bool load = true)
        {
            return load ? Js(url, JqueryValidatePath, JqueryValidateUnobtrusivePath) : MvcHtmlString.Empty;
        }

        public static MvcHtmlString My97DatePickerJs(this UrlHelper url, bool load = true)
        {
            return load ? Js(url, My97DatePickerPath) : MvcHtmlString.Empty;
        }

        public static MvcHtmlString Js(this UrlHelper url, params string[] filePath)
        {
            return LoadScript(url, ScriptBasePath, filePath);
        }

        public static MvcHtmlString AssetsJs(this UrlHelper url, params string[] filePath)
        {
            return LoadScript(url, AssetsBasePath, filePath);
        }

        private static MvcHtmlString LoadScript(this UrlHelper url, string rootPath, params string[] filePath)
        {
            return LoadResource(url, "<script src=\"{0}\" type=\"text/javascript\"></script>", rootPath, filePath);
        }

        #endregion js

        public static int ToNoMin(this int id, int min = 0)
        {
            if (id <= min)
            {
                return min;
            }

            return id;
        }

        #region private

        private static MvcHtmlString LoadResource(this UrlHelper url, string format, string rootPath,
            params string[] filePath)
        {
            var sb = new StringBuilder();

            if (filePath != null && filePath.Length > 0)
            {
                filePath.Each(s => sb.AppendFormat(format, url.Content(rootPath + s)));
            }

            return MvcHtmlString.Create(sb.ToString());
        }

        private const string AssetsBasePath = "~/Assets/";

        private const string ScriptBasePath = AssetsBasePath + "js/";

        private const string JQueryBasePath = "jquery-1.11.0.min.js";
        private const string JqueryValidatePath = "jquery.validate.min.js";
        private const string JqueryValidateUnobtrusivePath = "jquery.validate.unobtrusive.min.js";

        private const string My97DatePickerPath = "My97DatePicker/WdatePicker.js";

        private const string CssBasePath = AssetsBasePath + "css/";

        #endregion private
    }

    /// <summary>
    /// Aspose License
    /// </summary>
    public static class AsposeLicense
    {
        public const string Key =
            "PExpY2Vuc2U+DQogIDxEYXRhPg0KICAgIDxMaWNlbnNlZFRvPkFzcG9zZSBTY290bGFuZCB" +
            "UZWFtPC9MaWNlbnNlZFRvPg0KICAgIDxFbWFpbFRvPmJpbGx5Lmx1bmRpZUBhc3Bvc2UuY2" +
            "9tPC9FbWFpbFRvPg0KICAgIDxMaWNlbnNlVHlwZT5EZXZlbG9wZXIgT0VNPC9MaWNlbnNlV" +
            "HlwZT4NCiAgICA8TGljZW5zZU5vdGU+TGltaXRlZCB0byAxIGRldmVsb3BlciwgdW5saW1p" +
            "dGVkIHBoeXNpY2FsIGxvY2F0aW9uczwvTGljZW5zZU5vdGU+DQogICAgPE9yZGVySUQ+MTQ" +
            "wNDA4MDUyMzI0PC9PcmRlcklEPg0KICAgIDxVc2VySUQ+OTQyMzY8L1VzZXJJRD4NCiAgIC" +
            "A8T0VNPlRoaXMgaXMgYSByZWRpc3RyaWJ1dGFibGUgbGljZW5zZTwvT0VNPg0KICAgIDxQc" +
            "m9kdWN0cz4NCiAgICAgIDxQcm9kdWN0PkFzcG9zZS5Ub3RhbCBmb3IgLk5FVDwvUHJvZHVj" +
            "dD4NCiAgICA8L1Byb2R1Y3RzPg0KICAgIDxFZGl0aW9uVHlwZT5FbnRlcnByaXNlPC9FZGl" +
            "0aW9uVHlwZT4NCiAgICA8U2VyaWFsTnVtYmVyPjlhNTk1NDdjLTQxZjAtNDI4Yi1iYTcyLT" +
            "djNDM2OGYxNTFkNzwvU2VyaWFsTnVtYmVyPg0KICAgIDxTdWJzY3JpcHRpb25FeHBpcnk+M" +
            "jAxNTEyMzE8L1N1YnNjcmlwdGlvbkV4cGlyeT4NCiAgICA8TGljZW5zZVZlcnNpb24+My4w" +
            "PC9MaWNlbnNlVmVyc2lvbj4NCiAgICA8TGljZW5zZUluc3RydWN0aW9ucz5odHRwOi8vd3d" +
            "3LmFzcG9zZS5jb20vY29ycG9yYXRlL3B1cmNoYXNlL2xpY2Vuc2UtaW5zdHJ1Y3Rpb25zLm" +
            "FzcHg8L0xpY2Vuc2VJbnN0cnVjdGlvbnM+DQogIDwvRGF0YT4NCiAgPFNpZ25hdHVyZT5GT" +
            "zNQSHNibGdEdDhGNTlzTVQxbDFhbXlpOXFrMlY2RThkUWtJUDdMZFRKU3hEaWJORUZ1MXpP" +
            "aW5RYnFGZkt2L3J1dHR2Y3hvUk9rYzF0VWUwRHRPNmNQMVpmNkowVmVtZ1NZOGkvTFpFQ1R" +
            "Hc3pScUpWUVJaME1vVm5CaHVQQUprNWVsaTdmaFZjRjhoV2QzRTRYUTNMemZtSkN1YWoyTk" +
            "V0ZVJpNUhyZmc9PC9TaWduYXR1cmU+DQo8L0xpY2Vuc2U+";

        public static Stream LStream = (Stream) new MemoryStream(Convert.FromBase64String(AsposeLicense.Key));
    }
}