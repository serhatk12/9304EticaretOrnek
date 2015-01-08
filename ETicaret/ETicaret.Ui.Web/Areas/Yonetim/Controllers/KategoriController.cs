using ETicaret.Data.Orm;
using ETicaret.Types;
using ETicaret.Ui.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Ui.Web.Areas.Yonetim.Controllers
{
    public class KategoriController : BaseController
    {
        public ViewResult Ekle()
        {
            KategoriListesiYukle();
            return View();
        }


        [HttpPost, ValidRequired]
        public JsonResult Ekle(Kategori model)
        {
         
            IslemSonucu sonuc = Servis.Kategori.Ekle(model);
            return JSonuc(sonuc);

        }


        void KategoriListesiYukle()
        {
            ViewData["kategoriListe"] = Servis.Kategori.HepsiniGetir(x => x.UstKategori == null).
                Select(x => new SelectListItem
                {
                    Text = x.Ad,
                    Value = x.Id.ToString(),
                });
            var model = Servis.Kategori.HepsiniGetir();


        }
    }
}