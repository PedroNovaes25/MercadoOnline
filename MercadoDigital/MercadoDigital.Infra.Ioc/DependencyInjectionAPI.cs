using MercadoDigital.Application.IServices;
using MercadoDigital.Application.Mappings;
using MercadoDigital.Application.Services;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Infra.Data.Connection;
using MercadoDigital.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Infra.Ioc
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<MercadoDbContext>
            (
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
            
            return services;
        }

        public static IServiceCollection AddDependencyServiceGroup(this IServiceCollection services) 
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICategoryProductService, CategoryProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddDependencyRepositoryGroup(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, EnderecoRepository>();
            services.AddScoped<ICategoryProductRepository, CategoryProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGeneralRepository<MercadoDbContext>, GeneralRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
