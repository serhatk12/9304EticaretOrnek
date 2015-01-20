using ETicaret.Data.Orm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Ui.Web.Controllers
{
    public class HomeController : LayoutController
    {

        public ViewResult Index()
        {
            return View();
        }

        public PartialViewResult UrunSlider()
        {
            //HACK Serhat generic slider ekliyecek.
            List<Urun> urunList = Servis.Urun.HepsiniGetir();
            return PartialView("Partial/_productIntro",urunList);
        }

        public PartialViewResult IndirimdekiUrunler()
        {
            List<Urun> model = Servis.Urun.HepsiniGetir(x => x.IndirimYuzde > 0);
            ViewBag.Message1 = "İndirimdeki";
            ViewBag.Message2 = "Ürünler";
            return PartialView("Partial/urunGrid",
                model);

        }

        public PartialViewResult SonEklenen()
        {
            //HACK Tüm ürünleri çekmiyelim.
            List<Urun> model = Servis.Urun.HepsiniGetir().OrderByDescending(x => x.Id).Take(12).ToList();
            ViewBag.Message1 = "Son eklenen";
            ViewBag.Message2 = "Ürünler";
            return PartialView("Partial/urunGrid", model);
        }
    }
}