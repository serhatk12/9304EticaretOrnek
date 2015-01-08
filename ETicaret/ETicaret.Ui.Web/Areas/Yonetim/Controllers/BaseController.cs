using ETicaret.Service;
using ETicaret.Types;
using ETicaret.Ui.Web.Areas.Yonetim.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Ui.Web.Areas.Yonetim.Controllers
{
    [LoginRequired]
    public class BaseController : Controller
    {
        protected ServisNoktasi Servis;

        public BaseController()
        {
            Servis = new ServisNoktasi();
        }


        protected override void Dispose(bool disposing)
        {
            Servis.Dispose();

            base.Dispose(disposing);
        }

        public JsonResult JSonuc(IslemSonucu sonuc)
        {
            return Json(sonuc.JsonaCevir(), JsonRequestBehavior.AllowGet);
        }
        
       
    }
}