using MercadoDigital.Application.Mappings;
using MercadoDigital.Infra.Ioc;
using Microsoft.OpenApi.Models;
using System.Drawing;

namespace MercadoDigital.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureService(IServiceCollection services) 
        {
            services.AddDependencyDb(Configuration);
            
            services.AddDependencyIdentity();
            
            services.AddDependencyServiceGroup();
            services.AddDependencyRepositoryGroup();
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddDependencyJWT(Configuration);



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "teste3", Version = "v1" });
            //});

            ///

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArchMVC.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    //definir configurações
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] " +
                    "and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",

                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    //definir configurações
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            ///

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //comentar quando usar a inicialização por CreateHostBuilder
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
