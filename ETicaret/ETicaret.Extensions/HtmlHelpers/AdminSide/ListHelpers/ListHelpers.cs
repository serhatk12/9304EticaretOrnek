using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ETicaret.Extensions.HtmlHelpers.AdminSide.ListHelpers
{
    public static class ListHelpers
    {

        public static MvcHtmlString DeleteButton(this HtmlHelper helper, string deleteAdress, int id)
        {
            if(deleteAdress.EndsWith(id.ToString()) || deleteAdress.EndsWith(id.ToString()+"/"))
            {
                throw new ArgumentException("Delete Adress cannot ends with recordId");
            }
            if(!deleteAdress.EndsWith("/"))
            {
                deleteAdress += "/";
            }
            TagBuilder builder = new TagBuilder("button");
            builder.AddCssClass("btn btn-circle btn-danger");
            builder.InnerHtml = "<i class='fa fa-times'></i>";
            builder.Attributes.Add("onclick", String.Format("DeleteFromList('{0}',{1})", deleteAdress, id));
            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString UpdateButton(this HtmlHelper helper,string updateAdress)
        {
            TagBuilder builder = new TagBuilder("a");
            builder.AddCssClass("btn btn-circle btn-info");
            builder.Attributes.Add("href", updateAdress);
            builder.InnerHtml = "<i class='fa fa-pencil-square-o'></i>";
            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }

    }
}
