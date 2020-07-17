using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LocalImporter.Repositories.Interfaces
{
    public interface IEntityRead<TEntity>
    {
        Task<TModel> RetrieveFirst<TModel>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TModel>> selector);
        Task<List<TModel>> Retrieve<TModel>(Expression<Func<TEntity, TModel>> selector);
        Task<List<TModel>> Retrieve<TModel, TKey>(Expression<Func<TEntity, TModel>> selector, Expression<Func<TEntity, TKey>> order);
        Task<List<TModel>> Retrieve<TModel>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TModel>> selector);
        Task<List<TModel>> Retrieve<TModel, TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TModel>> selector, Expression<Func<TEntity, TKey>> order);
    }
}
