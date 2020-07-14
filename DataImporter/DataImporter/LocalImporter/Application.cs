using LocalImporter.Services.Interfaces;

namespace LocalImporter
{
    public class Application : IApplication
    {
        private readonly IDataMigrationService _migrationService;

        public Application(IDataMigrationService migrationService)
        {
            this._migrationService = migrationService;
        }

        public void Run()
        {
            this._migrationService.MigrateMatchData();
        }
    }
}
