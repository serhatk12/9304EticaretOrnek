﻿using ETicaret.Data.Dto;
using ETicaret.Data.Orm;
using ETicaret.Types;
using ETicaret.Ui.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization; //???

namespace ETicaret.Ui.Web.Areas.Yonetim.Controllers
{
    public class KategoriController : BaseController
    {
        public ViewResult Index()
        {            
            KategoriListesiYukle();
            List<Kategori> model = Servis.Kategori.HepsiniGetir(x=>x.UstKategori==null);
            return View(model);
        }

        [HttpPost]
        public ViewResult Index(int? kategoriId)
        {
            KategoriListesiYukle();
            List<Kategori> model = Servis.Kategori.HepsiniGetir(x => x.UstKategori == kategoriId);
            return View(model);
        }

        public ViewResult Sirala()
        {
            List<KategoriDto> model = Servis.Kategori.UstKategoriListesiDtoGetir();

            //TODO Siralamayı düzelt
            return View(model);
        }

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

        public ViewResult Duzenle(int id)
        {
            KategoriListesiYukle();
            Kategori model = Servis.Kategori.Bul(id);
            return View(model);
        }

        [HttpPost, ValidRequired]
        public JsonResult Duzenle(Kategori model)
        {
            IslemSonucu sonuc = Servis.Kategori.Duzenle(model);
            return JSonuc(sonuc);
        }

        [HttpPost]
        public JsonResult SiraDuzenle(string[] item)
        {
            int[] ids = item.ToList().Select(x => Convert.ToInt32(x)).ToArray();
            var result = Servis.Kategori.Sirala(ids);
            return JSonuc(result);
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

        public JsonResult Sil(int id)
        {
            var result = Servis.Kategori.Sil(id);
            return JSonuc(result);
        }
    }
}