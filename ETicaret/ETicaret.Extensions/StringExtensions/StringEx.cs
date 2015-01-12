using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Extensions.StringExtensions
{
    public static class StringEx
    {
        public static string ToClearString(this string value) //webdeyim.wordpress.com/2013/09/23/asp-net-ile-metinden-url-olusturma
        {
            value = value.Replace(",", "").Replace("\"", "").Replace("'", "").Replace(":", "").Replace(";", "").Replace(".", "").Replace("!", "").Replace("?", "").Replace(")", "").Replace("(", " ").Replace("&", " ").Replace(" ", " ");
            if (value.Length > 75)
            {
                value = value.Substring(0, 75);
                value = value.Substring(0, value.LastIndexOf(" "));
            }
            value = value.Replace(" ", "-").ToLower();
            return value.Replace("ş", "s").Replace("Ş", "s").Replace("ç", "c").Replace("Ç", "c").Replace("ö", "o").Replace("Ö", "o").Replace("ü", "u").Replace("Ü", "u").Replace("İ", "i").Replace("ı", "i").Replace("ğ", "g").Replace("Ğ", "g");
        }
    }
}
