using BusinessLogicLayer.Vaildations;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Add Business Logic Layer services here
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
     
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BusinessLogicLayer.behaviors.ValidationBehavior<,>));
            services.AddValidatorsFromAssemblyContaining<AddCustomerCommandValidator>();
            return services;
        }
    }
}
