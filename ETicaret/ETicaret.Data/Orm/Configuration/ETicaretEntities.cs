using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ETicaret.Data.Orm.Configration
{
    public class ETicaretEntities : DbContext
    {
        public ETicaretEntities()
        {
            Database.Connection.ConnectionString = "server=127.0.0.1;database=ETicaret;uid=sa;pwd=1234567?";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Kategori> Kategori { get; set; }

        public DbSet<Kullanici> Kullanici { get; set; }

        public DbSet<KullaniciAdres> KullaniciAdres { get; set; }

        public DbSet<Marka> Marka { get; set; }

        public DbSet<Resim> Resim { get; set; }

        public DbSet<Siparis> Siparis { get; set; }

        public DbSet<SiparisDetay> SiparisDetay { get; set; }

        public DbSet<Urun> Urun { get; set; }
    }
}
