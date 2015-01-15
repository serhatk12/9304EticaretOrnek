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
namespace ETicaret.Service.DataServices
{
    public class UrunService :ServiceBase<Urun>
    {
        public UrunService(ETicaretEntities context) : base(context) { }

        public override IslemSonucu Ekle(Urun entity)
        {
            if(Db.Urun.Any(x=>x.Ad == entity.Ad))
            {
                return Hatali("Aynı isimde başka bir ürün bulunuyor");
            }

            entity.SayfaYolu = entity.Ad.ToClearString();

            return base.Ekle(entity);
        }

    }
}
