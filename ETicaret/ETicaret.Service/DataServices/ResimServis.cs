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
    public class ResimServis : ServiceBase<Resim>
    {
        public ResimServis(ETicaretEntities context) : base(context) { }
    }
}
