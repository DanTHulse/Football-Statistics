using System.Collections.Generic;
using Common.Dto.Base;
using EFCore.BulkExtensions;
using LocalImporter.Repositories.Interfaces;

namespace LocalImporter.Repositories
{
    public class EntityWrite<T> : IEntityWrite<T> where T : BaseEntity
    {
        private readonly FutbolContext _context;

        public EntityWrite(FutbolContext context)
        {
            this._context = context;
        }

        public void Insert(T entity)
        {
            this._context.Add(entity);
            this._context.SaveChanges();
        }

        public void InsertRange(IList<T> range)
        {
            this._context.BulkInsert(range, new BulkConfig
            {
                SetOutputIdentity = true,
                PreserveInsertOrder = true,
            });
        }
    }
}
