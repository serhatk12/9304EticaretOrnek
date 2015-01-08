using ETicaret.Data.Orm;
using ETicaret.Data.Orm.Configration;
using ETicaret.Service.DataServices.Base;
using ETicaret.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.Extensions.StringExtensions;

namespace ETicaret.Service.DataServices
{
    public class KategoriServis : ServiceBase<Kategori>
    {
        public KategoriServis(ETicaretEntities context)
            : base(context)
        {

        }

        public override IslemSonucu Ekle(Kategori entity)
        {
            if (Db.Kategori.Any(x => x.Ad == entity.Ad))
            {
                return Hatali("Aynı isimde başka bir kategori mevcut");
            }
            entity.SayfaYolu = entity.Ad.ToClearString();
            return base.Ekle(entity);
        }

        public override IslemSonucu Duzenle(Kategori entity)
        {
            if (Db.Kategori.Any(x => x.Ad == entity.Ad && x.Id != entity.Id))
            {
                return Hatali("Aynı isimde başka bir kategori mevcut");
            }
            Kategori kat = base.Bul(entity.Id);
            if(kat ==null)
            {
                return Hatali("Kategori tespit edilemedi");
            }
            kat.SayfaYolu = entity.Ad.ToClearString();
            kat.Aciklama = entity.Aciklama;
            kat.Ad = entity.Ad;
            kat.UstKategori = entity.UstKategori;
            return base.Duzenle(kat);
        }
    }
}
