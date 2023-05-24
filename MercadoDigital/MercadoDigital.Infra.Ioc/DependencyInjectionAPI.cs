using MercadoDigital.Application.IServices;
using MercadoDigital.Application.Services;
using MercadoDigital.Application.Services.Account;
using MercadoDigital.Domain.Entities.Identity;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Infra.Data.Connection;
using MercadoDigital.Infra.Data.Identity;
using MercadoDigital.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MercadoDigital.Infra.Ioc
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddDependencyDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MercadoDbContext>
            (
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            return services;
        }

        //1° crio as regras para a criptografia da entidade user
        public static IServiceCollection AddDependencyIdentity(this IServiceCollection services)
        {

            services.AddIdentityCore<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<MercadoDbContext>()
            .AddDefaultTokenProviders(); 

            return services;
        }
        public static IServiceCollection AddDependencyServiceGroup(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticate, JwtService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICategoryProductService, CategoryProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderItemsService, OrderItemsService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IUserService, UserService>();
            // Depois ver como implementar: (ITokenCreationService no JwtService) services.AddScoped<ITokenCreationService, JwtService>();

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

        //2° crio as regras para a descriptografia do jwt
        public static IServiceCollection AddDependencyJWT(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:Key"])
                    )
                };
            });

            return services;
        }
    }
}
