using ETicaret.Ui.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Ui.Web.App_Start
{
    public class FilterConfig
    {


        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // projemiz yayınlandığında bu alan açıklamadan kaldırılacak.
            // harhangi bir istisna olduğunda gidilecek class.
           // filters.Add(new ErrorHandling());
        }

    }
}