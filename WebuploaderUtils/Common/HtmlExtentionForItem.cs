using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebuploaderUtils.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class HtmlExtentionForItem
    {
        public static object AutoContent(this HtmlHelper htmlHelper, Func<object, object> html)
        {
            if (html == null || htmlHelper.IsReadonly()) return MvcHtmlString.Empty;

            return html(htmlHelper.IsReadonly());
        }

        public static MvcHtmlString NecessaryFlag(this HtmlHelper html)
        {
            if (html.IsReadonly())
                return MvcHtmlString.Empty;
            return new MvcHtmlString("<label class='need'>*</label>");
        }

        public static MvcHtmlString NecessaryFlag<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            if (htmlHelper.IsEditable(expression))
            {
                return new MvcHtmlString("<label class='need'>*</label>");
            }

            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString Back(this HtmlHelper html)
        {
            return new MvcHtmlString("<input type='button' value='返回' onclick='if(window.history) history.back()' />");
        }


        public static MvcHtmlString AutoValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, bool show = true)
        {
            if (!show || !htmlHelper.IsEditable(expression))
                return MvcHtmlString.Empty;

            return htmlHelper.ValidationMessageFor(expression);
        }

        public static MvcHtmlString AutoTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            System.Linq.Expressions.Expression<Func<TModel, TProperty>> expression, object htmlAttributes,
            bool edit = true)
        {
            if (!edit || !htmlHelper.IsEditable(expression))
                return htmlHelper.DisplayTextFor(expression).Concat(htmlHelper.HiddenFor(expression));

            return htmlHelper.TextAreaFor(expression, htmlAttributes);
        }

        public static MvcHtmlString AutoTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, bool edit = true)
        {
            if (!edit || !htmlHelper.IsEditable(expression))
                return htmlHelper.DisplayTextFor(expression).Concat(htmlHelper.HiddenFor(expression));

            return htmlHelper.TextBoxFor(expression);
        }

        public static MvcHtmlString AutoTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            if (!htmlHelper.IsEditable(expression))
                return htmlHelper.DisplayTextFor(expression).Concat(htmlHelper.HiddenFor(expression));

            return htmlHelper.TextBoxFor(expression, htmlAttributes);
        }

        public static MvcHtmlString AutoTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool edit = true)
        {
            if (!edit || !htmlHelper.IsEditable(expression))
                return htmlHelper.DisplayTextFor(expression).Concat(htmlHelper.HiddenFor(expression));

            return htmlHelper.TextBoxFor(expression, htmlAttributes);
        }

        public static bool IsReadonly(this HtmlHelper html)
        {
            var o = html.ViewContext.Controller.ViewBag.___IsReadonly___;

            return o == null || !(o is bool) ? false : (bool) o;
        }

        public static bool IsEditable<TModel, TProperty>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression)
        {
            return IsEditable<TModel, TProperty>((HtmlHelper) html, expression);
        }

        public static bool IsEditable<TModel, TProperty>(this HtmlHelper html,
            Expression<Func<TModel, TProperty>> expression)
        {
            if (IsReadonly(html))
            {
                return false;
            }

            var o = html.ViewContext.Controller.ViewBag.___EditableProperties___ as IEnumerable<Expression>;
            if (o == null)
            {
                return true;
            }

            var propertyName = expression.ToString().Split(new char[] {'.'}, 2).LastOrDefault();
            return o.OfType<Expression<Func<TModel, TProperty>>>().Any(t => t.ToString().EndsWith("." + propertyName));
        }
    }
}