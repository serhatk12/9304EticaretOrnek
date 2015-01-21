using ETicaret.Data.Orm;
using ETicaret.Data.Orm.Configration;
using ETicaret.Service.DataServices.Base;
using ETicaret.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Service.DataServices
{
    public class YoneticiServis : ServiceBase<Yonetici>
    {
        public YoneticiServis(ETicaretEntities context)
            : base(context)
        {

        }

        public IslemSonucu GirisYap(Yonetici model)
        {
            Yonetici yonetici = Db.Yonetici.FirstOrDefault(x => x.KullaniciAdi == model.KullaniciAdi && x.Sifre == model.Sifre);
            if (yonetici == null)
            {
                return Hatali("Kullanıcı tespit edilemedi.");
            }
            model.Id = yonetici.Id;
            model.KullaniciAdi = yonetici.KullaniciAdi;
            return Basarili("");
        }

        public override IslemSonucu Ekle(Yonetici entity)
        {
            if (Db.Yonetici.Any(x => x.KullaniciAdi == entity.KullaniciAdi))
            {
                return Hatali("Kullanıcı adı mevcuttur.");
            }
            return base.Ekle(entity);
        }

        public override IslemSonucu Duzenle(Yonetici entity)
        {
            if (Db.Yonetici.Any(x => x.KullaniciAdi == entity.KullaniciAdi && entity.Id != x.Id))
            {
                return Hatali("Aynı kullanıcı adına sahip başka bir yönetici var.");
            }
            Yonetici yonetici = Bul(entity.Id);
            yonetici.KullaniciAdi = entity.KullaniciAdi;
            yonetici.Sifre = entity.Sifre;
            yonetici.Soyad = entity.Soyad;
            return base.Duzenle(yonetici);
        }
    }
}
