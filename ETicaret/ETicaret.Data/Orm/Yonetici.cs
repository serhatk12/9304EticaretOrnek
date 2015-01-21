using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Orm
{
    public class Yonetici : ModelBase
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "İsim boş geçilemez")]
        [Display(Name = "İsim")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyisim boş geçilemez")]
        [Display(Name = "Soyisim")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [Display(Name = "Şifre")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalı")]
        public string Sifre { get; set; }

        [Compare("Sifre", ErrorMessage = "Şifreler aynı değil.")]
        [Display(Name = "Şifre (Tekrar)")]
        [NotMapped]
        public string SifreTekrar { get; set; }
    }
}
