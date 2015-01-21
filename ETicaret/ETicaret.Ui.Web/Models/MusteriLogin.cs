using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaret.Ui.Web.Models
{
    public class MusteriLogin
    {
        [Required(ErrorMessage = "Eposta boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        public string EPosta { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Sifre { get; set; }
    }
}