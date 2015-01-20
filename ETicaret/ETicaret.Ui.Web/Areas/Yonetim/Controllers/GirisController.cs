using ETicaret.Data.Orm;
using ETicaret.Service;
using ETicaret.Types;
using ETicaret.Ui.Web.Areas.Yonetim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
namespace ETicaret.Ui.Web.Areas.Yonetim.Controllers
{
    public class GirisController : Controller
    {
        public ActionResult Index()
        {
            //if(HttpContext.User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "YoneticiAnasayfa");
            //}
            // TempData Actionlar arası veri taşımak için kullanıbilir.
            var routeValues = TempData["routeValues"];
            TempData["yonlendirmeDegerleri"] = routeValues;
            return View();
        }

        [HttpPost]
        public ActionResult Index(GirisModel model)
        {
            using (ServisNoktasi servis = new ServisNoktasi())
            {             
                if(ModelState.IsValid)
                {
                    Yonetici yonetici = new Yonetici();
                    yonetici.KullaniciAdi = model.KullaniciAdi;
                    yonetici.Sifre = model.Sifre;
                    IslemSonucu sonuc = servis.Yonetici.GirisYap(yonetici);
                    if (!sonuc.BasariliMi)
                    {
                        ModelState.AddModelError("HataliGiris", sonuc.Mesaj);
                        return View();
                    }
                    string userInfo = String.Format("admin;{0};{1}",yonetici.Id,yonetici.KullaniciAdi);
                    FormsAuthentication.SetAuthCookie(userInfo, true);

                    var routeValues = TempData["yonlendirmeDegerleri"];
                    if(routeValues!=null)
                    {
                        RouteValueDictionary values = (RouteValueDictionary)routeValues;
                        string action = values["action"].ToString();
                        string controller = values["controller"].ToString();
                        return RedirectToAction(action,controller,values);                   
                    }
                    return RedirectToAction("Index", "YoneticiAnasayfa");
                }            
                return View();               
            }            
        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}