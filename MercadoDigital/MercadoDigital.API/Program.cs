namespace MercadoDigital.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Modos de inicialização

            ////Inicialização 1
            var builder = WebApplication.CreateBuilder(args);
            var startup = new Startup(builder.Configuration);

            startup.ConfigureService(builder.Services);

            var app = builder.Build();
            startup.Configure(app, app.Environment);

            app.Run();

            //Inicialização 2

            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}