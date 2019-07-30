using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebuploaderUtils.Common
{
    /// <summary>
    /// Extended the HtmlHelper for WebUploader
    /// </summary>
    public static class WebUploaderExtensions
    {
        /// <summary>
        /// 使用特定的名称和初始值生成控件
        /// </summary>
        /// <param name="helper">HtmlHelper对象</param>
        /// <param name="name">控件名称</param>
        /// <param name="date">要显示的日期时间</param>
        /// <param name="format">显示格式</param>
        /// <returns>Html文本</returns>
        public static MvcHtmlString WebUploader(this HtmlHelper helper, string name, WebUploader model)
        {
            return GenerateHtml(helper, name, model ?? new WebUploader());
        }

        /// <summary>
        /// 通过lambda表达式生成控件
        /// </summary>
        /// <param name="helper">HtmlHelper对象</param>
        /// <param name="expression">lambda表达式，指定要显示的属性及其所属对象</param>
        /// <param name="model"></param>
        /// <returns>Html文本</returns>
        public static MvcHtmlString WebUploaderFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression, WebUploader model)
        {
            if (model == null)
            {
                model = new WebUploader();
            }

            string name = ExpressionHelper.GetExpressionText(expression);
            var val = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, helper.ViewData).Model;
            if (val != null)
            {
                model.Files = val.ToString();
            }

            return GenerateHtml(helper, name, model);
        }

        public static MvcHtmlString WebUploaderDisplayFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression)
        {
            string name = ExpressionHelper.GetExpressionText(expression);

            object data = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, helper.ViewData).Model;
            if (data != null)
            {
                StringBuilder stringBuilder = new StringBuilder("<ul class=\"list-unstyled f-file-list\">");
                var files = data.ToString().Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var item in files)
                {
                    stringBuilder.Append(string.Format("<li>{0}</li>", item.FileIcon(true, true)));
                }

                stringBuilder.Append("</ul>");
                return MvcHtmlString.Create(stringBuilder.ToString());
            }
            else
            {
                return MvcHtmlString.Empty;
            }
        }

        /// <summary>
        /// 生成输入框的Html
        /// </summary>
        /// <param name="name">WebUploader的名称</param>
        /// <param name="date">WebUploader的值</param>
        /// <returns>html文本</returns>
        private static MvcHtmlString GenerateHtml(this HtmlHelper html, string name, WebUploader model)
        {
            var map = new ViewDataDictionary();
            map["FileUploaderName"] = name;
            return html.Partial("_WebUploader", model, map);
        }
    }

    /// <summary>
    /// 上传文件类
    /// </summary>
    public class WebUploader
    {
        public WebUploader()
        {
            this.auto = true;
            this.FileNumLimit = 1;
            this.FileSingleSizeLimit = 2 * 1024 * 1022; //2M
            this.FileSizeLimit = 20 * 1024 * 1024; //20M
            this.ThumbnailHeight = 100;
            this.ThumbnailWidth = 100;
            this.ButtonText = "请选择文件";
            this.AcceptTitle = "请选择文件";
            this.UploadFileType = UploadFileType.File;
            this.Duplicate = false;
            this.ImgList = "";
        }

        /// <summary>
        /// 文件
        /// </summary>
        public string Files { get; set; }

        /// <summary>
        /// 上传文件类型
        /// </summary>
        public UploadFileType UploadFileType { get; set; }

        /// <summary>
        /// 文本名
        /// </summary>
        public string ButtonText { get; set; }

        /// <summary>
        /// 触发事件的元素id
        /// </summary>
        public string DomId { get; set; }

        /// <summary>
        /// 文本框模式
        /// </summary>
        public bool InputModel { get; set; }

        /// <summary>
        /// 是否自动上传
        /// </summary>
        public bool auto { get; set; }

        /// <summary>
        /// 服务端接收地址
        /// </summary>
        public string server { get; set; }

        /// <summary>
        /// 路径
        /// <para>如:/assets/userfiles/images/Net/usertemp/{yyyy}{mm}{dd}/{origin}{time}{rand:6}</para>
        /// </summary>
        public string PathFormat { get; set; }

        /// <summary>
        /// 缩略图的宽(px)
        /// <para>默认100px</para>
        /// </summary>
        public int ThumbnailWidth { get; set; }

        /// <summary>
        /// 缩略图的高(px)
        /// <para>默认100px</para>
        /// </summary>
        public int ThumbnailHeight { get; set; }

        /// <summary>
        /// 文件总数量
        /// </summary>
        public int FileNumLimit { get; set; }

        /// <summary>
        /// 文件总大小
        /// </summary>
        public int FileSizeLimit { get; set; }

        /// <summary>
        /// 单个文件大小
        /// </summary>
        public int FileSingleSizeLimit { get; set; }

        /// <summary>
        /// 文字描述;例:Images
        /// </summary>
        public string AcceptTitle { get; set; }

        /// <summary>
        /// 允许的文件后缀，不带点，多个用逗号分割;例:gif,jpg,jpeg,bmp,png
        /// </summary>
        public string AcceptExtensions { get; set; }

        /// <summary>
        /// 多个用逗号分割;例:image/*
        /// </summary>
        public string AcceptMimeTypes { get; set; }

        /// <summary>
        /// 文本框样式
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// button样式
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// table样式
        /// </summary>
        public string TableStyle { get; set; }

        /// <summary>
        /// 重复上传(默认不可以) false
        /// </summary>
        public bool Duplicate { get; set; }

        /// <summary>
        /// 默认为空，只有图片。else：图片+描述
        /// </summary>
        public string ImgList { get; set; }
    }
}