using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Orm
{
    public class Marka : ModelBase
    {
        [Required(ErrorMessage = "Marka adı boş geçilemez.")]
        [Display(Name = "Marka Adı")]
        public string Ad { get; set; }

        [Display(Name = "Marka Açıklaması")]
        public string Aciklama { get; set; }

        [Display(Name = "Resim Seçiniz")]
        public string ResimYolu { get; set; }

        public string SayfaYolu { get; set; }
    }
}
