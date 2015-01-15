using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Orm
{   
    public class Kategori : ModelBase
    {
        //Kullanıcıya görünecek değer
        [Display(Name="Üst Kategori")]
        public int? UstKategori { get; set; }

        [Required(ErrorMessage="Kategori adı boş geçilemez.")]
        [Display(Name="Kategori Adı")]
        public string Ad { get; set; }

        //HACK 'Ç' harfini desteklemiyor
        [Display(Name="Kategori Acıklaması")]
        public string Aciklama { get; set; }

        public string SayfaYolu { get; set; }


        public virtual List<Urun> Urunler { get; set; }
    }
}

