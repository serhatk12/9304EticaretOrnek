using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Orm
{
    public class Resim : ModelBase
    {
        public int UrunId { get; set; }

        public string KucukYol { get; set; }

        public string OrtaYol { get; set; }

        public string BuyukYol { get; set; }


        [ForeignKey("UrunId")]
        public virtual Urun Urun { get; set; }
    }
}
