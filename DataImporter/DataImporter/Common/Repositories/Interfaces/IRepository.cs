using System.Collections.Generic;

namespace LocalImporter.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> RetrieveAll();
        void InsertRange(IList<T> range);
    }
}
