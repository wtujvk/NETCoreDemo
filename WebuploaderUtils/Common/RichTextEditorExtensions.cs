using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebuploaderUtils.Common
{
    /// <summary>
    /// Extended the HtmlHelper for RichTextEditor
    /// </summary>
    public static class RichTextEditorExtensions
    {
        /// <summary>
        /// 使用特定的名称和初始值生成控件
        /// <para>一个页面只能使用一种类型编辑器</para>
        /// </summary>
        /// <param name="helper">HtmlHelper对象</param>
        /// <param name="name">控件名称</param>
        /// <param name="model">编辑器配置</param>
        /// <returns>Html文本</returns>
        public static MvcHtmlString RichTextEditor(this HtmlHelper helper, string name, RichTextEditor model)
        {
            return GenerateHtml(helper, name, model ?? new RichTextEditor());
        }

        /// <summary>
        /// 通过lambda表达式生成控件
        /// </summary>
        /// <param name="helper">HtmlHelper对象</param>
        /// <param name="expression">lambda表达式，指定要显示的属性及其所属对象</param>
        /// <param name="model"></param>
        /// <returns>Html文本</returns>
        public static MvcHtmlString RichTextEditorFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression, RichTextEditor model)
        {
            if (model == null)
            {
                model = new RichTextEditor();
            }

            string name = ExpressionHelper.GetExpressionText(expression);
            var val = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, helper.ViewData).Model;
            if (val != null)
            {
                model.Cnt = val.ToString();
            }

            return GenerateHtml(helper, name, model);
        }

        public static MvcHtmlString RichTextEditorDisplayFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression)
        {
            string name = ExpressionHelper.GetExpressionText(expression);

            object data = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, helper.ViewData).Model;
            if (data != null)
            {
                return MvcHtmlString.Create(data.ToString());
            }
            else
            {
                return MvcHtmlString.Empty;
            }
        }

        /// <summary>
        /// 生成编辑器的Html
        /// </summary>
        /// <param name="name">RichTextEditor的名称</param>
        /// <param name="date">RichTextEditor的值</param>
        /// <returns>html文本</returns>
        private static MvcHtmlString GenerateHtml(this HtmlHelper html, string name, RichTextEditor model)
        {
            var map = new ViewDataDictionary();
            map["RichTextEditorName"] = name;
            if (model.Plugins == RichTextEditorPlugins.UEDITOR)
            {
                return html.Partial("_UEditor", model, map);
            }

            return html.Partial("_RichTextEditor", model, map);
        }
    }

    /// <summary>
    /// 编辑器
    /// </summary>
    public class RichTextEditor
    {
        public RichTextEditor()
        {
            this.Plugins = RichTextEditorPlugins.UEDITOR;
            this.ToolBar = RichTextEditorToolBar.Base;
            this.AutoHeight = false;
            this.Width = 800;
            this.Height = 300;
        }

        /// <summary>
        /// 使用的插件
        /// </summary>
        public RichTextEditorPlugins Plugins { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Cnt { get; set; }

        /// <summary>
        /// 自动高
        /// <para>目前仅针对百度编辑器(ue、um)</para>
        /// </summary>
        public bool AutoHeight { get; set; }

        /// <summary>
        /// 工具栏
        /// </summary>
        public RichTextEditorToolBar ToolBar { get; set; }

        /// <summary>
        /// 编辑器宽
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 编辑器高
        /// </summary>
        public int Height { get; set; }
    }

    public enum RichTextEditorPlugins
    {
        /// <summary>
        /// CK Editor 功能强大的编辑器
        /// <para>推荐使用</para>
        /// </summary>
        CKEDITOR,

        /// <summary>
        /// Kinde Editor 一款国产的编辑器
        /// </summary>
        KINDEDITOR,

        /// <summary>
        /// UEditor 百度出的一款编辑器
        /// <para>界面更符合国人审美观</para>
        /// <para>推荐使用</para>
        /// </summary>
        UEDITOR,

        /// <summary>
        /// UMEditor UEditor的简化版
        /// <para>适合给网站用户(前台)使用</para>
        /// </summary>
        UMEDITOR
    }

    public enum RichTextEditorToolBar
    {
        /// <summary>
        /// 基础工具栏
        /// </summary>
        Base,

        /// <summary>
        /// 基础工具栏(带查看源码)
        /// </summary>
        BaseSource,

        /// <summary>
        /// 完整工具栏
        /// </summary>
        Full
    }
}