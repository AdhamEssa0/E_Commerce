using E_Commerce.Doman.Contracts;
using E_Commerce.Infrastracture.Data;
using E_Commerce.Infrastracture.Data.DataSeeding;
using E_Commerce.Infrastracture.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastracture
{
    public static class InfastructureServicesRegistration
    {
        public static IServiceCollection AddInfastructureServices(this IServiceCollection services , IConfiguration configration)
        {
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(configration.GetConnectionString("DefaultConnection"));
            });

            services.AddKeyedScoped<IDataSeeder, CatalogDataSeed>("Catalog");
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }


    }
}
