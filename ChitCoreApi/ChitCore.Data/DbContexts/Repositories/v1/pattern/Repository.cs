using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChitCore.Data.v1
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Members

        protected readonly DbContext dbContext;

        #endregion Members

        #region Constructors

        public Repository(DbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        #endregion Constructors


        #region Methods

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().AddRange(entities);
        }

        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }

        #endregion Methods
    }
}
