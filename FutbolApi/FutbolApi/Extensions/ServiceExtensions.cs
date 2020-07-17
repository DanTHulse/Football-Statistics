using Common.Dto;
using LocalImporter.Repositories;
using LocalImporter.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FutbolApi.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterRepository<TEntity>(this IServiceCollection services) where TEntity : BaseEntity
        {
            services.AddScoped<IEntityRead<TEntity>, EntityRead<TEntity>>();
            services.AddScoped<IEntityWrite<TEntity>, EntityWrite<TEntity>>();

            return services;
        }
    }
}
