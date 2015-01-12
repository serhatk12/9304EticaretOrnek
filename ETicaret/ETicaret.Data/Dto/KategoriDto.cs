using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Dto
{
    public class KategoriDto
    {

        public int Id { get; set; }

        public string Ad { get; set; }

        public List<KategoriDto> AltKategoriler { get; set; }
    }
}
