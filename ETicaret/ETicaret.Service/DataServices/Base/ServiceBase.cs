using ETicaret.Data.Orm;
using ETicaret.Data.Orm.Configration;
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
        private ETicaretEntities _dbContext;
        private DbSet<TEntity> _dbSet;

        public ServiceBase(ETicaretEntities dbContext)
        {     
            this._dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();          
        }

        public TEntity Bul(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id && !x.SilindiMi);
        }

        #region Listeleme

        public List<TEntity> HepsiniGetir()
        {        
           return _dbSet.Where(x => !x.SilindiMi).ToList();       
        }

        public List<TEntity> HepsiniGetir(Expression<Func<TEntity,bool>> filter)
        {
            return _dbSet.Where(x => !x.SilindiMi).Where(filter).ToList();         
        }

        #endregion

        //TODO Type' operation result ekle
        public void Sil(int id)
        {
            TEntity entity = _dbSet.Find(id);
            entity.SilindiMi = true;
            entity.SilinmeTarihi = DateTime.Now;
            _dbContext.SaveChanges();
        }

        //TODO Type' operation result ekle
        public void Ekle(TEntity entity)
        {
            entity.EklenmeTarihi = DateTime.Now;
            entity.SilindiMi = false;           //Buna gerek var mı?(Erhan)
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
