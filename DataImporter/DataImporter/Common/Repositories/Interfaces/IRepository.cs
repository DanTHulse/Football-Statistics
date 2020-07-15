using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LocalImporter.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> RetrieveAll();
        IEnumerable<S> Retrieve<S>(Expression<Func<T, S>> selector);
        IEnumerable<S> Retrieve<S, U>(Expression<Func<T, S>> selector, Expression<Func<T, U>> order);
        IEnumerable<S> Retrieve<S>(Expression<Func<T, bool>> filter, Expression<Func<T, S>> selector);
        void Insert(T entity);
        void InsertRange(IList<T> range);

        void InsertRangeV2(IList<T> range);
    }
}
