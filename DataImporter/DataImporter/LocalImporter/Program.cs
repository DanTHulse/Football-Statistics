using LocalImporter.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace LocalImporter
{
    class Program
    {
        static void Main()
        {
            var serviceProvider = DependencyRegistrar.Register();

            var app = serviceProvider.GetService<IApplication>();
            app.Run();
        }
    }
}
