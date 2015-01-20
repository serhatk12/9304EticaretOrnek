using ETicaret.Data.Orm.Configration;
using ETicaret.Service.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Service
{
    public class ServisNoktasi : IDisposable
    {
        private ETicaretEntities _context;

        public ServisNoktasi()
        {
            _context = new ETicaretEntities();
        }

        #region Tanımlama

        private YoneticiServis _yoneticiServis;

        private KategoriServis _kategoriServis;

        private UrunService _urunServis;

        private ResimServis _resimServis;

        private KullaniciServis _kullaniciServis;

        #endregion

        #region Oluşturma


        public KullaniciServis Kullanici
        {
            get
            {
                if(_kullaniciServis==null)
                {
                    _kullaniciServis = new KullaniciServis(_context);
                }
                return _kullaniciServis;
            }
        }

        public YoneticiServis Yonetici
        {
            get
            {
                if (_yoneticiServis == null)
                {
                    _yoneticiServis = new YoneticiServis(_context);
                }
                return _yoneticiServis;
            }
        }

        public KategoriServis Kategori
        {
            get
            {
                return _kategoriServis ?? (_kategoriServis = new KategoriServis(_context));
            }
        }


        public ResimServis Resim
        {
            get
            {
                return _resimServis ?? (_resimServis = new ResimServis(_context));
            }
        }

        public UrunService Urun
        {
            get
            {
                return _urunServis ?? (_urunServis = new UrunService(_context));
            }
        }

        #endregion

        private bool _disposed = false;

        public virtual void Dispose(bool disposed)
        {
            if (!disposed)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(_disposed);
            GC.SuppressFinalize(this);
        }
    }
}
