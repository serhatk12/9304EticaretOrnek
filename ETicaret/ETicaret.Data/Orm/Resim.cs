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

        [NotMapped]
        public string Resim140
        {
            get
            {
                return "/Content/images/urunler/140/" + this.KucukYol;
            }
        }

        [NotMapped]
        public string Resim300
        {
            get
            {
                return "/Content/images/urunler/300/" + this.OrtaYol;
            }
        }

        [NotMapped]
        public string ResimOrjinal
        {
            get
            {
                return "/Content/images/urunler/orjinal/" + this.BuyukYol;
            }
        }
    }
}
