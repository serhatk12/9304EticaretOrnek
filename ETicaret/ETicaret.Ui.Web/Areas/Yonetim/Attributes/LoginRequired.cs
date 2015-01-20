using ETicaret.Ui.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Ui.Web.Areas.Yonetim.Attributes
{
    public class LoginRequired : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CurrentUser.IsAdmin)
            {
                var da = filterContext.RouteData.Values;
                filterContext.Controller.TempData["routeValues"] = filterContext.RouteData.Values;
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"controller","giris"},
                    {"action","index"},                    
                });
            }
        }
    }
}