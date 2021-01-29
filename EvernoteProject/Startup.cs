using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Evernote.Application.StartupExtensions;
using Evernote.IoC;
using Evernote.Application.Configurations;

namespace Evernote.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;


        public Startup(IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(environment.ContentRootPath)
                            .AddJsonFile($"AppSettings/appsettings.json", optional: false, reloadOnChange: true)
                            .AddJsonFile($"AppSettings/appsettings.{environment.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables();
            Configuration = builder.Build();
            _env = environment;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomizedSwagger(_env);

            services.AddCustomizedDatabase(Configuration, _env);

            services.AddAutoMapperSetup();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5001","http://localhost:5000");
                    });
            });

            services.AddMvc().AddValidationSetup();

            NativeInjectorBootStrapper.RegisterServices(services, Configuration);

            services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else 
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCustomizedSwagger(env);

            app.UseRouting();

            app.UseCors();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
