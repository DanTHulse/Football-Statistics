using System.Collections.Generic;

namespace LocalImporter.Repositories.Interfaces
{
    public interface IEntityWrite<T>
    {
        void Insert(T entity);
        void InsertRange(IList<T> range);
    }
}
