using ETicaret.Data.Orm.Configration;
using ETicaret.Service.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Service
{
    public class ServisNoktasi :IDisposable
    {
        private ETicaretEntities _context;

        public ServisNoktasi()
        {
            _context = new ETicaretEntities();
        }

        #region Tanımlama

        private YoneticiServis _yoneticiService;

       

        #endregion

        #region Oluşturma

        public YoneticiServis Yonetici
        {
            get
            {
                if(_yoneticiService==null)
                {
                    _yoneticiService = new YoneticiServis(_context);
                }

                return _yoneticiService;
            }
        }

        #endregion

        private bool _disposed = false;

        public virtual void Dispose(bool disposed)
        {
           if(!disposed)
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
