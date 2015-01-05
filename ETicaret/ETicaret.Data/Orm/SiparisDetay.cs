using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Orm
{
    public class SiparisDetay : ModelBase
    {

        public int SiparisId { get; set; }

        public int UrunId { get; set; }

        public int Adet { get; set; }

        public int IndirimYuzde { get; set; }

        public Decimal Tutar { get; set; }

        [ForeignKey("SiparisId")]
        public virtual Siparis Siparis { get; set; }

        [ForeignKey("UrunId")]
        public virtual Urun Urun { get; set; }
    }
}
