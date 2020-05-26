using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaceShop.Context;
using FaceShop.Entities;
using FaceShop.Repository;
using FaceShop.Services;
using FaceShop.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FaceShop
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            //var builder = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddEnvironmentVariables();

            //Configuration = builder.Build();
            //ConnectionString = Configuration.GetConnectionString("FaceShopServiceContext");
            //Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            //if (env.IsDevelopment())
            //{
            //    // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
            //    builder.AddApplicationInsightsSettings(developerMode: true);
            //}

            Configuration = builder.Build();
        }

        public static string ConnectionString { get; set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton(provider => Configuration);
            //services.AddApplicationInsightsTelemetry(Configuration);

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddMvc();//.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            ConfigureRepository(services);
        }

        private void ConfigureRepository(IServiceCollection services)
        {
            services.AddScoped<DbContext, FaceShopServiceContext>()
                .AddScoped<IGenericRepository<Cart>, GenericRepository<Cart>>()
                .AddScoped<IGenericRepository<Order>, GenericRepository<Order>>()
                .AddScoped<IGenericRepository<OrderDetail>, GenericRepository<OrderDetail>>()
                .AddScoped<IGenericRepository<Product>, GenericRepository<Product>>()
                .AddScoped<IGenericRepository<User>, GenericRepository<User>>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
