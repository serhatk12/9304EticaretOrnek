using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETicaret.Data.Orm;
namespace ETicaret.Ui.Web.Models
{
    public class UrunDetayModel
    {
        public Urun Urun { get; set; }

        public List<Urun> BenzerUrunler { get; set; }
    }
}