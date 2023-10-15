using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Application.Common.Interfaces;
using WorldLeague.Infrastructure.Persistence.Configurations.Context;

namespace WorldLeague.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            var connectionString = configuration.GetConnectionString("PostgreSQL")!;

            // DbContext
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString, b => b.MigrationsAssembly("WorldLeague.WebApi")));


            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            // Scoped Services


            // Singleton Services

            return services;
        }
    }
}
