namespace ChillGames.WebApi
{
    using System;
    using System.IO;
    using System.Reflection;
    using Common;
    using Data.Repositories.GamesRepositories;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Data.StoreContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<StoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("StoreContext")));

            services.AddTransient<IGamesRepository, GamesRepository>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(SwaggerSettings.DocName, new OpenApiInfo
                {
                    Version = "v1",
                    Title = SwaggerSettings.Title,
                    Description = SwaggerSettings.Description
                });

                options.IncludeXmlComments(
                    Path.Combine(AppContext.BaseDirectory, string.Concat(typeof(Startup).Assembly.GetName().Name, ".xml")));
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/{SwaggerSettings.DocName}/swagger.json", "ChillGamesAPI");
            });
        }
    }
}
