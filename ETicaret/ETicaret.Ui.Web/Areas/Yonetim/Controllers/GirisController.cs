using ETicaret.Data.Orm;
using ETicaret.Service;
using ETicaret.Types;
using ETicaret.Ui.Web.Areas.Yonetim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Ui.Web.Areas.Yonetim.Controllers
{
    public class GirisController : Controller
    {

        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(GirisModel model)
        {
            using (ServisNoktasi servis = new ServisNoktasi())
            {
                Yonetici yonetici = new Yonetici();
                yonetici.KullaniciAdi = model.KullaniciAdi;
                yonetici.Sifre = model.Sifre;
                IslemSonucu sonuc = servis.Yonetici.GirisYap(yonetici);
                if(!sonuc.BasariliMi)
                {
                    ModelState.AddModelError("HataliGiris", sonuc.Mesaj);
                    return View();
                }
                return View();
               
            }

        }
    }
}