using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Orm
{
    public class ModelBase
    {
        [Key]
        public int Id { get; set; }

        public bool SilindiMi { get; set; }

        public DateTime EklenmeTarihi{get; set;}

        public DateTime? SonGuncelleme { get; set; }

        public DateTime? SilinmeTarihi { get; set; }

        public int SiraNumarasi { get; set; }
    }
}
