using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Orm
{
    public class Urun : ModelBase
    {
        [Required(ErrorMessage = "Ürün adı boş geçilemez.")]
        [Display(Name = "Urun Adı")]
        public string Ad { get; set; }


        [Display(Name = "Kategori seçiniz")]
        [Range(1, int.MaxValue, ErrorMessage = "Kategori boş geçilemez")]
        public int KategoriId { get; set; }


        [Display(Name = "Urun Acıklaması")]
        public string Aciklama { get; set; }

        [Display(Name = "Urun Net Fiyatı")]
        public Decimal Fiyat { get; set; }

        [Display(Name = "İndirim %")]
        [Range(0, 99, ErrorMessage = "Lütfen 0 ile 99 arasında bir sayı girin.")]
        public int IndirimYuzde { get; set; }

        [Display(Name = "Kalan Miktar")]
        public int StokMiktar { get; set; }

        public string SayfaYolu { get; set; }

        [NotMapped]
        public Decimal SonFiyat
        {
            get
            {
                return (Decimal)Fiyat - (Fiyat * IndirimYuzde / 100);
            }
        }

        [NotMapped]
        public bool IndirimVarMi
        {
            get
            {
                return IndirimYuzde != 0;
            }
        }

     

        public virtual List<Resim> Resimler { get; set; }

        [ForeignKey("KategoriId")]
        public virtual Kategori Kategori { get; set; }
    }
}
