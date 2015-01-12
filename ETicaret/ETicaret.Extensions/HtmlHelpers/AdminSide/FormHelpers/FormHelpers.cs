using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ETicaret.Extensions.HtmlHelpers.AdminSide.FormHelpers
{
    public static class FormHelpers
    {
        public static MvcHtmlString TextGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            TagBuilder builder = new TagBuilder("div");
            builder.AddCssClass("form-group");
            string labelText = helper.DisplayNameFor(expression).ToString();
            string input = helper.TextBoxFor(expression, new { @class = "form-control", @placeholder = labelText }).ToString();
            string validMessage = helper.ValidationMessageFor(expression).ToString();
            builder.InnerHtml = String.Format("<label>{0}</label>{1}<p class='help-block'>{2}</p>", labelText, input, validMessage);
            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString TextAreaGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            TagBuilder builder = new TagBuilder("div");
            builder.AddCssClass("form-group");
            string labelText = helper.DisplayNameFor(expression).ToString();
            string input = helper.TextAreaFor(expression, new { @class = "form-control", @placeholder = labelText }).ToString();
            string validMessage = helper.ValidationMessageFor(expression).ToString();
            builder.InnerHtml = String.Format("<label>{0}</label>{1}<p class='help-block'>{2}</p>", labelText, input, validMessage);
            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString DropDownGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string viewDataName)
        {
            TagBuilder builder = new TagBuilder("div");
            builder.AddCssClass("form-group");
            string labelText = helper.DisplayNameFor(expression).ToString();
            string dropDown = helper.DropDownListFor(expression, (IEnumerable<SelectListItem>)helper.ViewData[viewDataName], new { @class = "form-control" }).ToString();
            string validMessage = helper.ValidationMessageFor(expression).ToString();
            builder.InnerHtml = String.Format("<label>{0}</label>{1}<p class='help-block'>{2}</p>", labelText, dropDown, validMessage);
            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString DropDownGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string viewDataName, string optionLabel)
        {
            TagBuilder builder = new TagBuilder("div");
            builder.AddCssClass("form-group");
            string labelText = helper.DisplayNameFor(expression).ToString();
            string dropDown = helper.DropDownListFor(expression, (IEnumerable<SelectListItem>)helper.ViewData[viewDataName], optionLabel, new { @class = "form-control" }).ToString();
            string validMessage = helper.ValidationMessageFor(expression).ToString();
            builder.InnerHtml = String.Format("<label>{0}</label>{1}<p class='help-block'>{2}</p>", labelText, dropDown, validMessage);
            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString SubmitButton(this HtmlHelper helper,string value)
        {
            TagBuilder builder = new TagBuilder("button");
            builder.AddCssClass("btn btn-info");
            builder.Attributes.Add("type", "submit");
            builder.InnerHtml = value;
            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }
    }
}
