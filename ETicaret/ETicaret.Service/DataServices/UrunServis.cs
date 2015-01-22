using ETicaret.Data.Orm;
using ETicaret.Data.Orm.Configration;
using ETicaret.Service.DataServices.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.Extensions.StringExtensions;
using ETicaret.Types;
using ETicaret.Data.Dto;
using PagedList;
using System.Linq.Expressions;
namespace ETicaret.Service.DataServices
{
    public class UrunServis : ServiceBase<Urun>
    {
        public UrunServis(ETicaretEntities context) : base(context) { }

        public override IslemSonucu Ekle(Urun entity)
        {
            if (Db.Urun.Any(x => x.Ad == entity.Ad))
            {
                return Hatali("Aynı isimde başka bir ürün bulunuyor");
            }
            entity.SayfaYolu = entity.Ad.ToClearString();
            return base.Ekle(entity);
        }

        public IslemSonucu Sirala(int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                Urun urn = Db.Urun.Find(ids[i]);
                urn.SiraNumarasi = i;
                Db.SaveChanges();
            }
            return Basarili("Ürünler sıralandı");
        }

        public SepetDto SepetGetir(List<SepetDetayDto> sepet)
        {
            Decimal toplamTutar = 0;
            foreach (var item in sepet)
            {
                Urun urn = Db.Urun.FirstOrDefault(x => x.Id == item.UrunId);

                item.BirimFiyat = (urn.SonFiyat * item.Adet);
                item.UrunAdi = urn.Ad;

                toplamTutar += (item.BirimFiyat);


            }
            return new SepetDto
            {
                ToplamTutar = toplamTutar,
                SepetIcerik = sepet,
            };
        }

        public Urun SayfaYolunaGoreGetir(string sayfaYolu)
        {
            Urun urn = Db.Urun.FirstOrDefault(x => x.SayfaYolu == sayfaYolu);
            return urn;
        }


        public IPagedList<Urun> KategoriyeGoreGetir(string kategoriYolu, int page, string orderType)
        {

            string orderStyle = "asc";
            string orderBy = "SiraNumarasi";
            int pageSize = 1;
            if (!String.IsNullOrEmpty(orderType))
            {
                string[] orderValues = orderType.Split('-');
                orderStyle = orderValues[1];
                orderBy = orderValues[0];
            }
            IPagedList<Urun> urunler = null;

            Expression<Func<Urun, bool>> filterExpression = x => x.Kategori.SayfaYolu == kategoriYolu && !x.SilindiMi;

            switch (orderBy)
            {
                case "SiraNumarasi":
                    if (orderStyle == "asc")
                    {
                        urunler = Db.Urun.Where(filterExpression).OrderBy(x => x.SiraNumarasi)
          .ToPagedList(page, pageSize);
                    }
                    else
                    {
                        urunler = Db.Urun.Where(filterExpression).OrderByDescending(x => x.SiraNumarasi)
         .ToPagedList(page, pageSize);
                    }

                    break;


                case "Ad": 
                    if(orderStyle=="asc")
                    {
                        urunler = Db.Urun.Where(filterExpression).OrderBy(x => x.Ad).ToPagedList(page, pageSize); 
                    }
                    else
                    {
                        urunler = Db.Urun.Where(filterExpression).OrderByDescending(x => x.Ad).ToPagedList(page, pageSize); 
                    }
                    
                    break;

                case "Fiyat":
                    if(orderStyle=="asc")
                    {
                        urunler = Db.Urun.Where(filterExpression).OrderBy(x => x.Fiyat).ToPagedList(page, pageSize);
                    }
                    else
                    {
                        urunler = Db.Urun.Where(filterExpression).OrderByDescending(x => x.Fiyat).ToPagedList(page, pageSize);
                    }
                    
                    break;

            }




            return urunler;
        }
    }
}
