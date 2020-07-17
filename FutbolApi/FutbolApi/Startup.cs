using DataImporter.Common.Dto.Teams;
using FutbolApi.Extensions;
using FutbolApi.Services.Interfaces;
using LocalImporter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FutbolApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddControllers();

            _ = services.AddDbContext<FutbolContext>(options => options.UseSqlServer(this.Configuration["ConnectionStrings:DbConnection"]));

            _ = services.RegisterRepository<TeamHeader>();

            _ = services.Scan(s =>
                s.FromApplicationDependencies()
                .AddClasses(c => c.AssignableTo<IService>())
                .AsImplementedInterfaces()
                .WithTransientLifetime());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }

            _ = app.UseRouting();

            _ = app.UseEndpoints(e =>
            {
                e.MapControllers();
            });
        }
    }
}
