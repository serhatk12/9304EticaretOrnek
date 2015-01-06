using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaret.Ui.Web.Areas.Yonetim.Models
{
    public class GirisModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage="Şifre boş geçilemez")]
        public string Sifre { get; set; }
    }
}