using Evernote.APIClone.Repositories.Notes;
using Evernote.Domain.IRepositories;
using Evernote.Domain.IServices;
using Evernote.Infrastructure.Services.Notes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evernote.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration) 
        {
            //services.AddDbContext<EvernoteDbContext>(opts =>
            //{
            //    opts.UseSqlServer(configuration.GetConnectionString("Database"));
            //}, ServiceLifetime.Singleton
            //);
            services.AddHttpContextAccessor();


            services.AddSingleton<INotesRepository, NotesRepository>();
            services.AddSingleton<INotesService, NotesService>();

        }
    }
}
