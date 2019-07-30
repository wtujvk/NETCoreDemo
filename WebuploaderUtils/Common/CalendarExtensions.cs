using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebuploaderUtils.Extensions;

namespace WebuploaderUtils.Common
{
    /// <summary>
    /// Extended the HtmlHelper for Calendar
    /// </summary>
    public static class CalendarExtensions
    {
        /// <summary>
        /// 使用特定的名称和初始值生成控件
        /// </summary>
        /// <param name="helper">HtmlHelper对象</param>
        /// <param name="name">控件名称</param>
        /// <param name="date">要显示的日期时间</param>
        /// <param name="format">显示格式</param>
        /// <returns>Html文本</returns>
        public static MvcHtmlString Calendar(this HtmlHelper helper, string name, DateTime? date = null,
            string format = "yyyy-MM-dd")
        {
            return GenerateHtml(helper, name, date, format);
        }

        /// <summary>
        /// 通过lambda表达式生成控件
        /// </summary>
        /// <param name="helper">HtmlHelper对象</param>
        /// <param name="expression">lambda表达式，指定要显示的属性及其所属对象</param>
        /// <param name="format">显示格式</param>
        /// <returns>Html文本</returns>
        public static MvcHtmlString CalendarFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression, string format = "yyyy-MM-dd")
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            DateTime? value = null;
            DateTime t;
            object data = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, helper.ViewData).Model;
            if (data != null && DateTime.TryParse(data.ToString(), out t))
            {
                value = t;
            }

            return GenerateHtml(helper, name, value, format);
        }

        /// <summary>
        /// 通过lambda表达式生成控件
        /// </summary>
        /// <param name="helper">HtmlHelper对象</param>
        /// <param name="expression">lambda表达式，指定要显示的属性及其所属对象</param>
        /// <param name="format">显示格式</param>
        /// <returns>Html文本</returns>
        public static MvcHtmlString NullableCalendarFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression, string format = "yyyy-MM-dd")
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            DateTime? value = null;
            DateTime t;
            object data = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, helper.ViewData).Model;
            if (data != null && DateTime.TryParse(data.ToString(), out t))
            {
                if (t == DateTime.MinValue)
                    value = null;
                else
                    value = t;
                //return helper.TextBox(name, t.ToString("yyyy-MM-dd"), new { @readonly="readonly" });
            }

            return GenerateHtml(helper, name, value, format);
        }

        /// <summary>
        /// 通过lambda表达式获取要显示的日期时间
        /// </summary>
        /// <param name="helper">HtmlHelper对象</param>
        /// <param name="expression">lambda表达式，指定要显示的属性及其所属对象</param>
        /// <param name="format">显示格式</param>
        /// <returns>Html文本</returns>
        public static MvcHtmlString CalendarDisplayFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            DateTime value;
            object data = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, helper.ViewData).Model;
            if (data != null && DateTime.TryParse(data.ToString(), out value))
            {
                if (value == DateTime.MinValue)
                {
                    return MvcHtmlString.Empty;
                }

                return MvcHtmlString.Create(value.String());
            }
            else
            {
                return MvcHtmlString.Empty;
            }
        }

        /// <summary>
        /// 生成输入框的Html
        /// </summary>
        /// <param name="name">calendar的名称</param>
        /// <param name="date">calendar的值</param>
        /// <returns>html文本</returns>
        private static MvcHtmlString GenerateHtml(this HtmlHelper html, string name, DateTime? date,
            string format = "yyyy-MM-dd")
        {
            var map = new ViewDataDictionary();
            map["DateTimeName"] = name;
            map["DateFormat"] = format;
            return html.Partial("_DateTime", date, map);
        }
    }
}