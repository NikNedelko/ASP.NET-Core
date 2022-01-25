using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data;
using MySqlConnector.Authentication;
using MySql.Data.MySqlClient;
using MySqlConnector.Logging;
using Shop.Data;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;
using Shop.Data.Repository;
using Microsoft.AspNetCore.Http;
using Shop.Data.Models;

namespace Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContent>(options => { options.UseMySql(Configuration.GetConnectionString("Default")); });
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();// сервис для работ с сессиями
            services.AddScoped(sp => ShopCart.GetCart(sp));//корзина будет уникальна для каждого пользователя

            services.AddSession();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            //services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
            routes.MapRoute(name: "default",template: "{controller=Home}/{action=Index}/{id?}");
            routes.MapRoute(name: "categoryFilter",template: "Car/{action}/{category?}",defaults: new{Controller="Car",Action="List"}); 



            });
            /*
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });
            */
            
            using (var scope = app.ApplicationServices.CreateScope()){
            AppDbContent content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
            DbObjects.Initial(content);
            };

}
    }
}
