using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Backpack.Mvc.Helpers
{
    public static class CheckboxHelper
    {
        #region Bootstrap/HTML 5 Check Box Helpers
        /// <summary>
        /// Bootstrap and HTML 5 Check Box.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="text">The text to display next to this check box.</param>
        /// <returns>An HTML checkbox with the appropriate type set.</returns>
        public static MvcHtmlString CheckBoxBootstrapFor<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          string id,
          string text,
          object htmlAttributes = null)
        {
            return CheckBoxBootstrapFor(htmlHelper, expression, id, text, false, false, false, htmlAttributes);
        }

        /// <summary>
        /// Bootstrap and HTML 5 Check Box in a Button Helper.
        /// This helper assumes you have added the appropriate CSS to style this check box.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="text">The text to display next to this check box.</param>
        /// <param name="isChecked">Whether or not to set the 'checked' attribute on this check box.</param>
        /// <param name="isAutoFocus">Whether or not to set the 'autofocus' attribute on this check box.</param>
        /// <param name="useInline">Whether or not to use 'checkbox-inline' for the Bootstrap class.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML checkbox with the appropriate type set.</returns>
        public static MvcHtmlString CheckBoxBootstrapFor<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          string id,
          string text,
          bool isChecked,
          bool isAutoFocus,
          bool useInline = false,
          object htmlAttributes = null)
        {
            StringBuilder sb = new StringBuilder(512);
            string htmlChecked = string.Empty;
            string htmlAutoFocus = string.Empty;

            if (isChecked)
            {
                htmlChecked = "checked='checked'";
            }
            if (isAutoFocus)
            {
                htmlAutoFocus = "autofocus='autofocus'";
            }

            // Build the CheckBox
            if (useInline)
            {
                sb.Append("<label class='checkbox-inline'>");
            }
            else
            {
                sb.Append("<div class='checkbox'>");
                sb.Append("  <label>");
            }
            sb.AppendFormat("    <input id='{0}' name='{0}' type='checkbox' value='true' {1} {2}/><input name='{0}' type='hidden' value='false' {3} />",
                            id, htmlChecked, htmlAutoFocus,
                            HtmlExtensionsHelper.GetHtmlAttributes(htmlAttributes));
            sb.AppendFormat("    {0}", text);
            if (useInline)
            {
                sb.Append("</label>");
            }
            else
            {
                sb.Append("  </label>");
                sb.Append("</div>");
            }

            // Return an MVC HTML String
            return MvcHtmlString.Create(sb.ToString());
        }
        #endregion

        #region Bootstrap/HTML 5 Check Box in a Button Helpers
        /// <summary>
        /// Bootstrap and HTML 5 Check Box in a Button Helper.
        /// This helper assumes you have added the appropriate CSS to style this check box.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="text">The text to display next to this check box.</param>
        /// <returns>An HTML checkbox with the appropriate type set.</returns>
        public static MvcHtmlString CheckBoxButtonFor<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          string id,
          string text,
          object htmlAttributes = null)
        {
            return CheckBoxButtonFor(htmlHelper, expression, id, text, null, false, false, false, htmlAttributes);
        }

        /// <summary>
        /// Bootstrap and HTML 5 Check Box in a Button Helper.
        /// This helper assumes you have added the appropriate CSS to style this check box.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="text">The text to display next to this check box.</param>
        /// <param name="btnClass">The Bootstrap 'btn-' class to add to this check box.</param>
        /// <returns>An HTML checkbox with the appropriate type set.</returns>
        public static MvcHtmlString CheckBoxButtonFor<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          string id,
          string text,
          string btnClass,
          object htmlAttributes = null)
        {
            return CheckBoxButtonFor(htmlHelper, expression, id, text, btnClass, false, false, false, htmlAttributes);
        }

        /// <summary>
        /// Bootstrap and HTML 5 Check Box in a Button Helper.
        /// This helper assumes you have added the appropriate CSS to style this check box.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="text">The text to display next to this check box.</param>
        /// <param name="btnClass">The Bootstrap 'btn-' class to add to this check box.</param>
        /// <param name="isChecked">Whether or not to set the 'checked' attribute on this check box.</param>
        /// <param name="isAutoFocus">Whether or not to set the 'autofocus' attribute on this check box.</param>
        /// <param name="useInline">Whether or not to use 'checkbox-inline' for the Bootstrap class.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML checkbox with the appropriate type set.</returns>
        public static MvcHtmlString CheckBoxButtonFor<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          string id,
          string text,
          string btnClass,
          bool isChecked,
          bool isAutoFocus,
          bool useInline = false,
          object htmlAttributes = null)
        {
            StringBuilder sb = new StringBuilder(512);
            string htmlChecked = string.Empty;
            string htmlAutoFocus = string.Empty;
            string chkClass = "checkbox";

            if (string.IsNullOrEmpty(btnClass))
            {
                btnClass = "btn-default";
            }
            if (isChecked)
            {
                htmlChecked = "checked='checked'";
            }
            if (isAutoFocus)
            {
                htmlChecked = "autofocus='autofocus'";
            }
            if (useInline)
            {
                chkClass = "checkbox-inline";
            }

            // Build the CheckBox
            sb.AppendFormat("<div class='{0}'>", chkClass);
            sb.AppendFormat("  <label class='btn {0}'>", btnClass);
            sb.AppendFormat("    <input id='{0}' name='{0}' type='checkbox' value='true' {1} {2}/><input name='{0}' type='hidden' value='false' {3} />",
                            id, htmlChecked, htmlAutoFocus,
                           HtmlExtensionsHelper.GetHtmlAttributes(htmlAttributes));
            sb.AppendFormat("    {0}", text);
            sb.Append("  </label>");
            sb.Append("</div>");

            // Return an MVC HTML String
            return MvcHtmlString.Create(sb.ToString());
        }
        #endregion
    }
}
