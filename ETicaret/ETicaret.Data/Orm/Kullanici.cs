using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Orm
{
    public class Kullanici : ModelBase
    {
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        [Required(ErrorMessage = "E-posta adresi boş geçilemez.")]
        [Display(Name = "E-posta Adresiniz")]
        public string Eposta { get; set; }

        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [Display(Name = "Şifreniz")]
        public string Sifre { get; set; }

        [NotMapped]
        [Compare("Sifre", ErrorMessage = "Şifreler aynı değil.")]
        [Display(Name = "Şifreniz (Tekrar)")]
        public string SifreTekrar { get; set; }

        [Required(ErrorMessage = "Ad boş geçilemez.")]
        [Display(Name = "Adınız")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad boş geçilemez.")]
        [Display(Name = "Soyadınız")]
        public string Soyad { get; set; }

        [Phone(ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz.")]
        [Required(ErrorMessage="Telefon numarası boş geçilemez.")]
        [Display(Name="Telefon numaranız")]
        public string Telefon { get; set; }

        public virtual List<KullaniciAdres>  Adresler { get; set; }

        public virtual List<Siparis> Siparisler { get; set; }
    }
}
