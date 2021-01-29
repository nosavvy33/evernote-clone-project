using Evernote.API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Evernote.Application.StartupExtensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddCustomizedDatabase(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddDbContext<EvernoteDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("Database"));
                if (!env.IsProduction())
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                }
            }, ServiceLifetime.Singleton);


            return services;
        }
    }
}
