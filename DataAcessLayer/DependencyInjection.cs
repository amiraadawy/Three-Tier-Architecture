using DataAcessLayer.Data;
using DataAcessLayer.Entities;
using DataAcessLayer.Interfaces;
using DataAcessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(connectionString));
            // Add Data Access Layer services here
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<Customer>), typeof(CustomerRepository));
            return services;
        }
    }
}
