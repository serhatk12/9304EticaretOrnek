using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaret.Ui.Web.Models
{
    public static class CurrentUser
    {

        public static int Id
        {
            get
            {
             

                return Convert.ToInt32(HttpContext.Current.User.Identity.Name.Split(';')[0]);
            }
        }

        public static string KullaniciAdi
        {
            get
            {
                return HttpContext.Current.User.Identity.Name.Split(';')[1];
            }
        }
    }
}