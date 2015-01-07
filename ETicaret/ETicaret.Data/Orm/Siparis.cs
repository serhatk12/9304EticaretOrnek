using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Orm
{
    public class Siparis : ModelBase
    {
        public int KullaniciId { get; set; }

        public int AdresId { get; set; }

        [Display(Name="Eklemek istedikleriniz")]
        public string Aciklama { get; set; }

        [ForeignKey("KullaniciId")]
        public virtual Kullanici Kullanici { get; set; }

        [ForeignKey("AdresId")]
        public virtual KullaniciAdres Adres { get; set; }

        public virtual List<SiparisDetay> Detaylar { get; set; }
    }
}
