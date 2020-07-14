using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Common.Dto;
using EFCore.BulkExtensions;
using LocalImporter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocalImporter.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly FutbolContext _context;
        private readonly DbSet<T> _entities;

        public Repository(FutbolContext context)
        {
            this._context = context;
            this._entities = context.Set<T>();
        }

        public IEnumerable<T> RetrieveAll()
        {
            return this._entities.AsEnumerable();
        }

        public IEnumerable<S> Retrieve<S>(Expression<Func<T, bool>> filter, Expression<Func<T, S>> selector)
        {
            return this._entities.Where(filter).Distinct().Select(selector);
        }

        public void Insert(T entity)
        {
            this._context.Add(entity);
            this._context.SaveChanges();
        }

        public void InsertRange(IList<T> range)
        {
            this._context.BulkInsert(range);
        }
    }
}
