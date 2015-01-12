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
using ETicaret.Data.Dto;

namespace ETicaret.Service.DataServices
{
    public class KategoriServis : ServiceBase<Kategori>
    {
        public KategoriServis(ETicaretEntities context)
            : base(context)
        {

        }

        public List<KategoriDto> DtoGetir()
        {
            List<Kategori> kategoriListesi = base.HepsiniGetir();

            List<KategoriDto> katList = kategoriListesi.
                Where(x => x.UstKategori == null).Select(
                x => new KategoriDto
                {
                    Ad = x.Ad,
                    Id = x.Id,
                    AltKategoriler = kategoriListesi.Where(z => z.UstKategori == x.Id).
                    Select(z => new KategoriDto
                    {
                        Id = z.Id,
                        Ad = z.Ad,
                    }).ToList()
                }
                ).ToList();
            return katList;

        }

        public override IslemSonucu Ekle(Kategori entity)
        {
            if (Db.Kategori.Any(x => x.Ad == entity.Ad))
            {
                return Hatali("Aynı isimde başka bir kategori mevcut");
            }
            entity.SayfaYolu = entity.Ad.ToClearString();
            IslemSonucu sonuc = base.Ekle(entity);
            sonuc.Kayit = sonuc.BasariliMi ? entity : null;
            return sonuc;

        }

        public override IslemSonucu Duzenle(Kategori entity)
        {
            if (Db.Kategori.Any(x => x.Ad == entity.Ad && x.Id != entity.Id))
            {
                return Hatali("Aynı isimde başka bir kategori mevcut");
            }
            Kategori kat = base.Bul(entity.Id);
            if (kat == null)
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
