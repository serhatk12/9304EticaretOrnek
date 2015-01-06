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
    public class KullaniciServis : ServiceBase<Kullanici>
    {
        public KullaniciServis(ETicaretEntities dbContext):base(dbContext)
        {

        }

        public override IslemSonucu Ekle(Kullanici entity)
        {
            if(Db.Kullanici.Any(x=>x.Eposta==entity.Eposta))
            {
                return Hatali("Aynı EPosta adresine sahip başka bir kullanıcı mevcuttur.");
            }
            return base.Ekle(entity);
        }

        public override IslemSonucu Duzenle(Kullanici entity)
        {
            if(Db.Kullanici.Any(x=>x.Eposta==entity.Eposta && entity.Id != x.Id))
            {
                return Hatali("Aynı EPosta adresine sahip başka bir kullanıcı mevcuttur.");
            }
            Kullanici kayit = Bul(entity.Id);
            if (kayit == null) return Hatali("Kullanıcı tespit edilemedi");
            kayit.Eposta = entity.Eposta;
            kayit.Ad = entity.Ad;
            kayit.Soyad = entity.Soyad;
            kayit.Telefon = entity.Telefon;
            return base.Duzenle(kayit);
        }
    }
}
