using System.Collections.Generic;

namespace ChitFundMgmtApi.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();        

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
