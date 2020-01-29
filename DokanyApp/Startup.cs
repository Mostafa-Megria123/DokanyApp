using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DokanyApp.DAL;
using AutoMapper;
using DokanyApp.BLL;
using DokanyApp.Services;
using DokanyApp.BLL.AutoMapperService;
using NLog;
using System;
using System.IO;

namespace DokanyApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // To Make AutoMapper Compatible With the Version Of Solution (typeof(Startup))
            services.AddAutoMapper(typeof(Startup)); 
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Our Customized Services
            services.ConfigureCors();
            services.ConfigureSwaggerService();
            services.ConfigureDIServices();
            services.ConfigureAuthenticationServices();
            services.ConfigureAuthorizationServices();

            // Redis Cache
            services.AddDistributedRedisCache(r =>
            {
                r.Configuration = Configuration["redis:connectionString"];
            });

            var configuration = new MapperConfiguration(cfg => {
                 cfg.CreateMap<Product, ProductDTO>();
                 cfg.AddProfile<MapperExtension>();
            });

            services.ConfigureJwtAuthentication();
            services.AddDbContext<EFUnitOfWork>(options =>
                options.UseSqlServer(
                   Configuration.GetConnectionString("Dokany")));
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
                app.UseHsts();
            }

            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(Options =>
            {
                Options.SwaggerEndpoint("/swagger/v1/swagger.json", "My service");
                //Options.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMiddleware<TokenManagerMiddleware>();
            app.UseMvc();
        }
    }
}
