using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Orm
{
    public class KullaniciAdres : ModelBase
    {
        public int KullaniciId { get; set; }

        [Required(ErrorMessage = "Adres adı boş geçilemez.")]
        [Display(Name = "Adresiniz için bir ad giriniz")]
        public string AdresAdi { get; set; }

        [Required(ErrorMessage = "Şehir boş geçilemez.")]
        [Display(Name = "Şehir")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Adres boş geçilemez.")]
        [Display(Name = "Adresiniz")]
        public string Adres { get; set; }

        [ForeignKey("KullaniciId")]
        public virtual Kullanici Kullanici { get; set; }
    }
}
