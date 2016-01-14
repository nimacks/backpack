using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Backpack.Mvc.Helpers
{
    public static class TextBoxHelper
    {
        #region Bootstrap/HTML 5 TextBox Helpers
        /// <summary>
        /// Bootstrap and HTML 5 Text Box Helper
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML input element with the appropriate type set.</returns>
        public static MvcHtmlString TextBox5For<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          object htmlAttributes = null)
        {
            return TextBox5For(htmlHelper, expression, Html5InputTypes.text, string.Empty, string.Empty, false, false, htmlAttributes);
        }

        /// <summary>
        /// Bootstrap and HTML 5 Text Box Helper
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="type">The text type to set (text, password, date, tel, email, etc.).</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML input element with the appropriate type set.</returns>
        public static MvcHtmlString TextBox5For<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          Html5InputTypes type,
          object htmlAttributes = null)
        {
            return TextBox5For(htmlHelper, expression, type, string.Empty, string.Empty, false, false, htmlAttributes);
        }

        /// <summary>
        /// Bootstrap and HTML 5 Text Box Helper
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="title">The HTML 5 'title' attribute to set.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML input element with the appropriate type set.</returns>
        public static MvcHtmlString TextBox5For<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          string title,
          object htmlAttributes = null)
        {
            return TextBox5For(htmlHelper, expression, Html5InputTypes.text, title, title, false, false, htmlAttributes);
        }

        /// <summary>
        /// Bootstrap and HTML 5 Text Box Helper
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="type">The text type to set (text, password, date, tel, email, etc.).</param>
        /// <param name="title">The HTML 5 'title' attribute to set.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML input element with the appropriate type set.</returns>
        public static MvcHtmlString TextBox5For<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          Html5InputTypes type,
          string title,
          object htmlAttributes = null)
        {
            return TextBox5For(htmlHelper, expression, type, title, title, false, false, htmlAttributes);
        }

        /// <summary>
        /// Bootstrap and HTML 5 Text Box Helper
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="title">The HTML 5 'title' attribute to set.</param>
        /// <param name="isRequired">Whether or not to set the 'required' attribute on this text box.</param>
        /// <param name="isAutoFocus">Whether or not to set the 'autofocus' attribute on this text box.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML input element with the appropriate type set.</returns>
        public static MvcHtmlString TextBox5For<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          string title,
          bool isRequired,
          bool isAutoFocus,
          object htmlAttributes = null)
        {
            return TextBox5For(htmlHelper, expression, Html5InputTypes.text, title, title, isRequired, isAutoFocus, htmlAttributes);
        }

        /// <summary>
        /// Bootstrap and HTML 5 Text Box Helper
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="type">The text type to set (text, password, date, tel, email, etc.).</param>
        /// <param name="title">The HTML 5 'title' attribute to set.</param>
        /// <param name="placeholder">The HTML 5 'placeholder' attribute to set.</param>
        /// <param name="isRequired">Whether or not to set the 'required' attribute on this text box.</param>
        /// <param name="isAutoFocus">Whether or not to set the 'autofocus' attribute on this text box.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML input element with the appropriate type set.</returns>
        public static MvcHtmlString TextBox5For<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          Html5InputTypes type,
          string title,
          string placeholder,
          bool isRequired,
          bool isAutoFocus,
          object htmlAttributes = null)
        {
            MvcHtmlString html = default(MvcHtmlString);
            Dictionary<string, object> attr = new Dictionary<string, object>();

            if (htmlAttributes != null)
            {
                var attributes =
                  HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                foreach (var item in attributes)
                {
                    attr.Add(item.Key, item.Value);
                }
            }

            attr.Add("type", type.ToString());
            attr.Add("class", "form-control");
            if (!string.IsNullOrEmpty(title))
            {
                attr.Add("title", title);
            }
            if (!string.IsNullOrEmpty(placeholder))
            {
                attr.Add("placeholder", placeholder);
            }
            if (isAutoFocus)
            {
                attr.Add("autofocus", "autofocus");
            }
            if (isRequired)
            {
                attr.Add("required", "required");
            }

            html = InputExtensions.TextBoxFor(htmlHelper,
                                              expression,
                                              attr);

            return html;
        }
        #endregion
    }
}
