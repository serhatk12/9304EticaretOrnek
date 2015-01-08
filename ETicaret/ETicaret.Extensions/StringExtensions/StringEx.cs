using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Extensions.StringExtensions
{
    public  static class StringEx
    {

        public static string ToClearString(this string value)
        {
            string retValue = value.ToLower();
            retValue = retValue.Trim();

            //TODO set clear
            return retValue;
        }
    }
}
