﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace T10_P1_2_start.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(object id);

        void Insert(TEntity entity);

        void Delete(object id);

        IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
    }
}
