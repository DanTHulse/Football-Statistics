using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common.Dto.Base;
using LocalImporter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocalImporter.Repositories
{
    public class EntityRead<TEntity> : IEntityRead<TEntity> where TEntity : BaseEntity
    {
        private readonly FutbolContext _context;
        private readonly DbSet<TEntity> _entities;

        public EntityRead(FutbolContext context)
        {
            this._context = context;
            this._entities = context.Set<TEntity>();
        }

        public Task<TModel> RetrieveFirst<TModel>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TModel>> selector)
        {
            return this._entities.Where(filter).Select(selector).FirstOrDefaultAsync();
        }

        public Task<List<TModel>> Retrieve<TModel>(Expression<Func<TEntity, TModel>> selector)
        {
            return this._entities.Select(selector).ToListAsync();
        }

        public Task<List<TModel>> Retrieve<TModel, TKey>(Expression<Func<TEntity, TModel>> selector, Expression<Func<TEntity, TKey>> order)
        {
            return this._entities.OrderBy(order).Select(selector).ToListAsync();
        }

        public Task<List<TModel>> Retrieve<TModel>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TModel>> selector)
        {
            return this._entities.Where(filter).Distinct().Select(selector).ToListAsync();
        }

        public Task<List<TModel>> Retrieve<TModel, TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TModel>> selector, Expression<Func<TEntity, TKey>> order)
        {
            return this._entities.Where(filter).OrderBy(order).Select(selector).ToListAsync();
        }
    }
}
