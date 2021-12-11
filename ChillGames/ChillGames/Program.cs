namespace ChillGames.WebApi
{
    using System;
    using AutoMapper;
    using Data.DbInitializer;
    using Data.StoreContext;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            InitializeDb(host.Services);
            
            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void InitializeDb(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var scopeServices = scope.ServiceProvider;
                
            var dbContext = (StoreDbContext)scopeServices.GetService(typeof(StoreDbContext));
            var initializePath = "DbInitializeFiles";
            var mapper = (IMapper)scopeServices.GetService(typeof(IMapper));

            var storeDbInitializer = new StoreDbInitializer(dbContext, initializePath, mapper);
            
            storeDbInitializer.Initialize();
        }
    }
}
