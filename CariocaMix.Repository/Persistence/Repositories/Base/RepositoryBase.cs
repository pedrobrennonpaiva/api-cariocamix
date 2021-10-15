using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CariocaMix.Domain.Entities.Base;
using CariocaMix.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CariocaMix.Repository.Persistence.Repositories.Base
{
    public class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId>
        where TEntity : BaseModel
        where TId : struct
    {
        private readonly DbContext _context;
        private IDbContextTransaction _transation;

        public RepositoryBase(Context context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity;
        }

        public IEnumerable<TEntity> AddList(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            return entities;
        }

        public TEntity Edit(TEntity entity)
        {
            var local = _context.Set<TEntity>()
                        .Local
                        .FirstOrDefault(entry => entry.Id.Equals(entity.Id));

            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public bool Exist(Func<TEntity, bool> where)
        {
            return _context.Set<TEntity>().Any(where);
        }

        public TEntity GetBy(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return List(includeProperties).FirstOrDefault(where);
        }

        public TEntity GetById(TId id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return List(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }

            return _context.Set<TEntity>().Find(id);
        }

        public TEntity GetByLong(long id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return List(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }

            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> List(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntity>(), includeProperties);
            }

            return query;
        }

        public IQueryable<TEntity> ListAndSortedBy<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> order, bool ascendent = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return ascendent ? ListBy(where, includeProperties).OrderBy(order) : ListBy(where, includeProperties).OrderByDescending(order);
        }

        public IQueryable<TEntity> ListBy(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return List(includeProperties).Where(where);
        }

        public IQueryable<TEntity> ListSortedBy<TKey>(Expression<Func<TEntity, TKey>> order, bool ascendent = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return ascendent ? List(includeProperties).OrderBy(order) : List(includeProperties).OrderByDescending(order);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        private IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void BeginTransation()
        {
            _transation = _context.Database.BeginTransaction();
        }

        public void TransationCommit()
        {
            _transation.Commit();
        }

        public void TransationRollback()
        {
            _transation.Rollback();
        }
    }
}
