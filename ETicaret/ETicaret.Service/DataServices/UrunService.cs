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
namespace ETicaret.Service.DataServices
{
    public class UrunService : ServiceBase<Urun>
    {
        public UrunService(ETicaretEntities context) : base(context) { }

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

                item.BirimFiyat = urn.SonFiyat;
                item.UrunAdi = urn.Ad;
                toplamTutar += (item.BirimFiyat * item.Adet);
            }
            return new SepetDto
            {
                ToplamTutar = toplamTutar,
                SepetIcerik = sepet,
            };

        }

    }
}
