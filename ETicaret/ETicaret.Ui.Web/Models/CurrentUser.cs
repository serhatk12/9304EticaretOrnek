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
                return Convert.ToInt32(HttpContext.Current.User.Identity.Name.Split(';')[1]);
            }
        }

        public static string KullaniciAdi
        {
            get
            {
                return HttpContext.Current.User.Identity.Name.Split(';')[2];
            }
        }

        public static bool OturumAcikMi
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        public static bool IsAdmin
        {
            get
            {
                return CurrentUser.OturumAcikMi ? HttpContext.Current.User.Identity.Name.Split(';')[0] == "admin" : false;
            }
        }
    }
}