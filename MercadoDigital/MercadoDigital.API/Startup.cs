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
            services.AddConfig(Configuration)
                .AddDependencyServiceGroup()
                .AddDependencyRepositoryGroup();

            services.AddAutoMapper(typeof(MapperProfile));

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "teste3", Version = "v1" });
            });
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
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
