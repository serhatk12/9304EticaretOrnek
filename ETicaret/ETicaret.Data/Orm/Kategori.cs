using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Orm
{
   
    public class Kategori :ModelBase
    {
        //Kullanıcıya gözükecek değer
        [Display(Name="Üst Kategori")]
        public int? UstKategori { get; set; }

        [Required(ErrorMessage="Bu alan boş geçilemez")]
        [Display(Name="Kategori Adi")]
        public string Ad { get; set; }

        [Display(Name="Kategori Açıklaması")]
        public string Aciklama { get; set; }

        public string SayfaYolu { get; set; }



    }
}

