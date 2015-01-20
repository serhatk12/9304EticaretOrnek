using ETicaret.Data.Orm;
using ETicaret.Ui.Web.Areas.Yonetim.Controllers;
using ETicaret.Ui.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ETicaret.Ui.Web.Controllers
{
    public class LoginController : BaseController
    {

        public ActionResult GirisYap()
        {

            if (CurrentUser.IsAdmin)
            {
                FormsAuthentication.SignOut();
            }

            else if (CurrentUser.OturumAcikMi)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult GirisYap(MusteriLogin model)
        {
            
            Kullanici kullanici = new Kullanici{
            Eposta = model.EPosta,
            Sifre = model.Sifre,
            };
            var response = Servis.Kullanici.GirisYap(kullanici);
            if(response.BasariliMi)
            {
                string loginnedValues = string.Format("user;{0};{1}",kullanici.Id,kullanici.Ad+" "+kullanici.Soyad);
                FormsAuthentication.SetAuthCookie(loginnedValues,true);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("InvalidLogin", "Girmiş oluduğunuz bilgiler yanlıştır..!");
            return View();
        }

    }
}