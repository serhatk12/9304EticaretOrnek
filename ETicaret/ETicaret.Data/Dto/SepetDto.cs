using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Dto
{
    public class SepetDto
    {

        public Decimal ToplamTutar { get; set; }

        public List<SepetDetayDto> SepetIcerik { get; set; }

    }
}
