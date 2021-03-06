﻿using ETicaret.Data.Dto;
using ETicaret.Data.Orm;
using ETicaret.Ui.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Ui.Web.Controllers
{
    public class SiteUrunController : LayoutController
    {
       
        public ViewResult UrunDetay(string pageSlug)
        {

            Urun urn = Servis.Urun.SayfaYolunaGoreGetir(pageSlug);
            UrunDetayModel model = new UrunDetayModel();
            model.Urun = urn;
            model.BenzerUrunler = Servis.Urun.HepsiniGetir(x => x.KategoriId == urn.KategoriId && x.Id != urn.Id).OrderByDescending(x => x.Id).Take(6).ToList();
            return View(model);
        }

        public ViewResult KategoriyeGoreGetir(string pageSlug,int? page,string orderType)
        {
            page = page ?? 1;
            ViewBag.OrderType = orderType;
            IPagedList<Urun> urunler = Servis.Urun.KategoriyeGoreGetir(pageSlug, ((int)page),orderType);
            return View(urunler);

        }
     
    }
}