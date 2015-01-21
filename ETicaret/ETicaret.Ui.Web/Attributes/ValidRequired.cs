using ETicaret.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Ui.Web.Attributes
{
    public class ValidRequired : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                IslemSonucu sonuc = new IslemSonucu
                {
                    BasariliMi = false,
                    Mesaj = "Girmiş olduğunuz değerler uygun değildir. Sayfayı yenileyip tekrar deneyin.",
                };
                filterContext.Result = new JsonResult()
                {
                    Data = sonuc.JsonaCevir(),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                };
            }
            base.OnActionExecuting(filterContext);
        }
    }
}