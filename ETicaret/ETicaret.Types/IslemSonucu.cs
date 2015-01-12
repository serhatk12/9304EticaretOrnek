using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Types
{
    public class IslemSonucu
    {
        public int KayitId { get; set; }

        public string Mesaj { get; set; }

        public bool BasariliMi { get; set; }

        public JsonSonuc JsonaCevir()
        {
           return new JsonSonuc
            {
                BasariliMi = this.BasariliMi,
                CssClass = this.BasariliMi?"alert alert-info":"alert alert-danger",
                KayitId = this.KayitId,
                Mesaj = this.Mesaj
            };
        }
    }
}
