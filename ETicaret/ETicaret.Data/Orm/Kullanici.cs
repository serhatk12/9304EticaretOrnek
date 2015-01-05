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
        [EmailAddress(ErrorMessage = "Lütfen uygun bir E-posta Adresi Giriniz")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [Display(Name = "E postanız")]
        public string Eposta { get; set; }

        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalı")]
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [Display(Name = "Şifreniz")]
        public string Sifre { get; set; }

        [NotMapped]
        [Compare("Sifre", ErrorMessage = "Şifreler uyuşmuyor.")]
        [Display(Name = "Şifreniz (Tekrar)")]
        public string SifreTekrar { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [Display(Name = "Adınız")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [Display(Name = "Soyadınız")]
        public string Soyad { get; set; }
        [Phone(ErrorMessage = "Lütfen uygun bir telefon numarası giriniz")]
        [Required(ErrorMessage="Bu alan boş geçilemez")]
        [Display(Name="Lütfen telefon numaranızı giriniz")]
        public string Telefon { get; set; }


        public virtual List<KullaniciAdres>  Adresler { get; set; }
    }
}
