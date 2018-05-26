using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BarbellHero.Repositories;
using System;
using BarbellHero.Repositories.Interfaces;
using Mapster;

namespace BarbellHero
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            HostingEnvironment = env;
            Configuration = configuration;
        }

        public IHostingEnvironment HostingEnvironment { get; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (HostingEnvironment.IsDevelopment())
            {
                services.AddEntityFrameworkNpgsql()
                    .AddDbContext<BarbellHeroDbContext>(options =>
                        options.UseNpgsql(Configuration["Data:DbContext:ConnectionString"]));
            }
            else 
            {
                var host = Environment.GetEnvironmentVariable("DB_HOST");
                var database = Environment.GetEnvironmentVariable("DB_NAME");
                var user = Environment.GetEnvironmentVariable("DB_USER");
                var port = Environment.GetEnvironmentVariable("DB_PORT");
                var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
                services.AddEntityFrameworkNpgsql()
                    .AddDbContext<BarbellHeroDbContext>(options =>
                        options.UseNpgsql($"User ID={user};Password={password};Server={host};Port={port};Database={database};"));
            }

            services.AddMvc();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddTransient<IMovementRepository, MovementRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            TypeAdapterConfig.GlobalSettings.Default.IgnoreMember((member, side) => member.Name.Equals("Id"));

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    // use docker-compose for client hostname
                    spa.UseProxyToSpaDevelopmentServer("http://client:4200");
                }
            });
        }
    }
}
