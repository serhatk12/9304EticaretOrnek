using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Orm
{
    public class KullaniciAdres :ModelBase
    {
        public int KullaniciId { get; set; }

        [Required(ErrorMessage="Bu alan boş geçilemez")]
        [Display(Name="Adresiniz için bir ad seçiniz")]
        public string AdresAdi { get; set; }
        [Required(ErrorMessage="Bu alan boş geçilemez")]
        [Display(Name="Sehir/Ilce")]
        public string Sehir { get; set; }

        [Required(ErrorMessage="Bu alan boş geçilemez")]
        [Display(Name="Adresinizi giriniz")]
        public string Adres { get; set; }

        [ForeignKey("KullaniciId")]
        public virtual Kullanici Kullanici { get; set; }
    }
}
