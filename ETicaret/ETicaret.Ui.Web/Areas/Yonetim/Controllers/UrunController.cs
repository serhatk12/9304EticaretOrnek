using ETicaret.Data.Dto;
using ETicaret.Data.Orm;
using FileUploader;
using FileUploader.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Ui.Web.Areas.Yonetim.Controllers
{
    public class UrunController : BaseController
    {

        public ViewResult Index()
        {
            List<Urun> model = Servis.Urun.HepsiniGetir();
            return View(model);
        }

        public ViewResult Ekle()
        {

            return View();
        }

        [HttpPost]
        public JsonResult Ekle(HttpPostedFileBase[] resimler, Urun model)
        {
            var cevap = Servis.Urun.Ekle(model);
            if (cevap.BasariliMi)
            {
                foreach (var item in resimler)
                {
                    using (ImageUploader uploader = new ImageUploader(item, "~/Content/images/urunler/orjinal"))
                    {
                        var uploadSonuc = uploader.UploadFile(model.SayfaYolu);
                        if (uploadSonuc.Status)
                        {
                            ThumbSettings settings = new ThumbSettings
                            {
                                NewFilePath = "~/Content/images/urunler/140",
                                OldFilePath = "~/Content/images/urunler/orjinal/" + uploadSonuc.FileName,
                                NewHeight = 140,
                                NewWidth = 140,
                            };
                            Resim rsm = new Resim();

                            rsm.UrunId = model.Id;
                            rsm.BuyukYol = uploadSonuc.FileName;

                            rsm.KucukYol = uploader.CreateThumb(settings);
                            settings.NewFilePath = "~/Content/images/urunler/300";
                            settings.NewHeight = 300;
                            settings.NewWidth = 300;
                            rsm.OrtaYol = uploader.CreateThumb(settings);
                            Servis.Resim.Ekle(rsm);
                        }
                    }
                }
            }
            return JSonuc(cevap);
        }

        public JsonResult GetCategory()
        {
            List<KategoriDto> kategoriList = Servis.Kategori.UstKategoriListesiDtoGetir();
            List<KategoriAutoComplete> autoComplate = new List<KategoriAutoComplete>();
            foreach (var item in kategoriList)
            {
                foreach (var subitem in item.AltKategoriler)
                {
                    autoComplate.Add(new KategoriAutoComplete { Id = subitem.Id, Label = subitem.Ad, Category = item.Ad });
                }
            }
            return Json(autoComplate, JsonRequestBehavior.AllowGet);
        }

        public ViewResult Sirala()
        {
            List<Urun> model = Servis.Urun.HepsiniGetir();
            return View(model);
        }

        [HttpPost]
        public JsonResult SiralamaYap(int[] ids)
        {
            var result = Servis.Urun.Sirala(ids);
            return JSonuc(result);
        }

        public JsonResult Sil(int id)
        {
            var result = Servis.Urun.Sil(id);

            return JSonuc(result);
        }

    }


}