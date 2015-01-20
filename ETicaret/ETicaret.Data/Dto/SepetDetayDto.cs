using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Dto
{
    public class SepetDetayDto
    {

        public string UrunAdi { get; set; }

        public int UrunId { get; set; }

        public int Adet { get; set; }

        public Decimal BirimFiyat { get; set; }
    }
}
