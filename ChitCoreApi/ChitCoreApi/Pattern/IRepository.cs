﻿using System.Collections.Generic;

namespace ChitCoreApi.Pattern
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Methods

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        #endregion Methods
    }
}