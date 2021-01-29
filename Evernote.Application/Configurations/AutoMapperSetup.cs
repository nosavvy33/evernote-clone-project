using AutoMapper;
using Evernote.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Evernote.Application.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AutoMapperConfig.RegisterMappings());
        }
    }
}
