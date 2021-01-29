using Evernote.Application.Validations;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Evernote.Application.Configurations
{
    public static class ValidationSetup
    {
        public static void AddValidationSetup(this IMvcBuilder services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ValidationConfig>());
        }
    }
}
