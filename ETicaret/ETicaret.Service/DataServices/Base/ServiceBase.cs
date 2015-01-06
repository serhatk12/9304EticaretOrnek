using ETicaret.Data.Orm;
using ETicaret.Data.Orm.Configration;
using ETicaret.Types;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Service.DataServices.Base
{
    public abstract class ServiceBase<TEntity> where TEntity : ModelBase
    {
        public ETicaretEntities Db;
        private DbSet<TEntity> _dbSet;
        private IslemSonucu _basarili;
        private IslemSonucu _hatali;
        public ServiceBase(ETicaretEntities dbContext)
        {
            this.Db = dbContext;
            _dbSet = Db.Set<TEntity>();
            _basarili = new IslemSonucu { BasariliMi = true };
            _hatali = new IslemSonucu { BasariliMi = false };
        }

        public TEntity Bul(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id && !x.SilindiMi);
        }

        #region Listeleme

        public virtual List<TEntity> HepsiniGetir()
        {
            return _dbSet.Where(x => !x.SilindiMi).ToList();
        }

        public virtual List<TEntity> HepsiniGetir(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(x => !x.SilindiMi).Where(filter).ToList();
        }

        #endregion


        #region ReturnTypes
        public IslemSonucu Basarili(string mesaj)
        {
            _basarili.Mesaj = mesaj;
            return _basarili;
        }
        public IslemSonucu Basarili(string mesaj, int kayitId)
        {
            _basarili.Mesaj = mesaj;
            _basarili.KayitId = kayitId;
            return _basarili;
        }

        public IslemSonucu Hatali(string mesaj)
        {
            _hatali.Mesaj = mesaj;
            return _hatali;
        }

        public IslemSonucu Hatali(string mesaj, int kayitId)
        {
            _hatali.Mesaj = mesaj;
            _hatali.KayitId = kayitId;
            return _hatali;
        }

        #endregion


        public virtual IslemSonucu Sil(int id)
        {
            TEntity entity = _dbSet.Find(id);
            entity.SilindiMi = true;
            entity.SilinmeTarihi = DateTime.Now;
            Db.SaveChanges();
            return Basarili("Kayıt başarıyla silinmiştir", id);

        }

        public virtual IslemSonucu Ekle(TEntity entity)
        {
            entity.EklenmeTarihi = DateTime.Now;
            entity.SilindiMi = false;           //Buna gerek var mı?(Erhan) var (ilker)
            _dbSet.Add(entity);
            Db.SaveChanges();
            return Basarili("Kayıt başarıyla eklenmiştir.");
        }

        public virtual IslemSonucu Duzenle(TEntity entity)
        {
            entity.SonGuncelleme = DateTime.Now;
            Db.SaveChanges();
            return Basarili("Kayıt başarıyla güncellenmiştir");
        }
    }
}
