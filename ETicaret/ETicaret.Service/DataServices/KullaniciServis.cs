using ETicaret.Data.Orm;
using ETicaret.Data.Orm.Configration;
using ETicaret.Service.DataServices.Base;
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
    }
}
