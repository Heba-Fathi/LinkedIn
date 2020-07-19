using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn.Repository
{
    public interface IRepository<TEntity>: IDisposable
    {
        IQueryable<TEntity> GetAll();
        List<TEntity> GetAllBind();
        TEntity GetById(params object[] id);
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}
