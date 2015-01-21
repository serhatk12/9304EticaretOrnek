using ETicaret.Data.Dto;
using ETicaret.Data.Orm;
using ETicaret.Service;
using ETicaret.Ui.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ETicaret.Ui.Web.Controllers
{
    public class LayoutController : Controller
    {
        protected ServisNoktasi Servis;

        public LayoutController()
        {
            Servis = new ServisNoktasi();
        }

        public PartialViewResult Kategoriler()
        {
            List<Kategori> kategoriListesi = Servis.Kategori.HepsiniGetir();

            List<KategoriDto> model = kategoriListesi
                .Where(x => x.UstKategori == null)
                .Select(x => new KategoriDto
                {
                    Ad = x.Ad,
                    Id = x.Id,
                    Sayfayolu = x.SayfaYolu,
                    SiraNo = x.SiraNumarasi,
                    AltKategoriler = kategoriListesi.
                    Where(z => z.UstKategori == x.Id).Select(z => new KategoriDto
                    {
                        Ad = z.Ad,
                        Id = z.Id,
                        Sayfayolu = x.SayfaYolu + "/" + z.SayfaYolu,
                        SiraNo = z.SiraNumarasi,
                    }).ToList()
                }).ToList();

            return PartialView("Partial/_categories", model);
        }

        public PartialViewResult Navigation()
        {
            if (CurrentUser.OturumAcikMi)
            {
                return PartialView("Partial/_navigationWithLogin");
            }
            else
            {
                return PartialView("Partial/_navigationNoLogin");
            }
        }

        public PartialViewResult Sepet()
        {
            HttpCookie cartCookie = Request.Cookies["cart"];
            SepetDto dto = new SepetDto();
            dto.SepetIcerik = new List<SepetDetayDto>();
            if(cartCookie!=null)
            {
                dto = new JavaScriptSerializer().Deserialize<SepetDto>(cartCookie.Value);
            }

            return PartialView("Partial/_sepet",dto);
        }

        [HttpPost]
        public JsonResult SepeteEkle(SepetDetayDto model)
        {
            SepetDto returnSepet;
            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpCookie cartCookie = new HttpCookie("cart");
            cartCookie.HttpOnly = false;
            cartCookie.Expires = DateTime.Now.AddYears(1);

            if (Request.Cookies["cart"] != null)
            {
                string cartInfo = Request.Cookies["cart"].Value;


                SepetDto sepet = js.Deserialize<SepetDto>(cartInfo);
                if (sepet.SepetIcerik == null)
                {
                    sepet.SepetIcerik = new List<SepetDetayDto>();
                }
                if (sepet.SepetIcerik.Any(x => x.UrunId == model.UrunId))
                {
                    var item = sepet.SepetIcerik.FirstOrDefault(x => x.UrunId == model.UrunId);
                    item.Adet += model.Adet;
                }
                else
                {
                    sepet.SepetIcerik.Add(model);
                }

                returnSepet = Servis.Urun.SepetGetir(sepet.SepetIcerik);
                string sepetJson = js.Serialize(returnSepet);
                cartCookie.Value = sepetJson;

            }
            else
            {
                List<SepetDetayDto> sepetDetayi = new List<SepetDetayDto>();
                sepetDetayi.Add(model);
                returnSepet = Servis.Urun.SepetGetir(sepetDetayi);
                string sepetJson = js.Serialize(returnSepet);
                cartCookie.Value = sepetJson;

            }
            Response.Cookies.Add(cartCookie);

            return Json(returnSepet, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            Servis.Dispose();
            base.Dispose(disposing);
        }
    }
}