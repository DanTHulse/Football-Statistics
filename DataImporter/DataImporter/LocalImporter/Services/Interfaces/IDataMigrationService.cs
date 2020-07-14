using LocalImporter.Infrastructure.Interfaces;

namespace LocalImporter.Services.Interfaces
{
    public interface IDataMigrationService : IService
    {
        void MigrateMatchData();
    }
}
