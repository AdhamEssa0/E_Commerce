using E_Commerce.Application.Contracts;
using E_Commerce.Application.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application
{
    public static class ApplicationServicesRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(C => { }, typeof(ApplicationServicesRegister).Assembly);
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService , BasketService>();
            services.AddScoped<ICacheService , CacheService>();

            return services;
        }
    }
}
