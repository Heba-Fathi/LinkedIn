using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn.Repository
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        TContext context;
        DbSet<TEntity> set;
        public Repository(TContext context)
        {
            this.context = context;
            set = context.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAll()
        {
            return set;
        }

        public List<TEntity> GetAllBind()
        {
            return set.ToList();
        }
        public TEntity GetById(params object[] id)
        {
            return set.Find(id);
        }
        public bool Add(TEntity entity)
        {
            set.Add(entity);
            return context.SaveChanges() > 0;
        }

        public bool Update(TEntity entity)
        {
            set.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges() > 0;
        }
        public bool Delete(TEntity entity)
        {
            set.Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
            return context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            
        }
    }
}
