using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BethanyPieShop.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BethanyPieShop
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            //tell the system for appsettings.json file
            _configurationRoot = new ConfigurationBuilder()
                           .SetBasePath(hostingEnvironment.ContentRootPath)
                           .AddJsonFile("appsettings.json")
                           .Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
          
            //register custome AppDbContext cls with conn-str in appsettings.json file
            services.AddDbContext<AppDbContext>(options =>
                                        options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            //register identity roles cls for use
            services.AddIdentity<IdentityUser, IdentityRole>()
                                     .AddEntityFrameworkStores<AppDbContext>();
            //register custome Repository cls 
            /*
            services.AddTransient<ICategoryRepository, MockCategoryRepository>();
            services.AddTransient<IPieRepository, MockPieRepository>();
            */
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPieRepository, PieRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//register the http-context for use

            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));//register and call getCart method in ShoppingCart
            services.AddTransient<IOrderRepository, OrderRepository>();//register 

            //register MVC service
            services.AddMvc();
            //register memory-cashe,  session-state in application
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //inject the middleware component
            app.UseDeveloperExceptionPage();//inject dev-ex-page that provide friendly ex page
            app.UseStatusCodePages();//provide error code(400-500) in browser page
            app.UseStaticFiles();
            app.UseSession();//inject  sesion-state
            app.UseIdentity(); //inject the indentity membership-api for entitycore DB
            //app.UseMvcWithDefaultRoute();// only for mvc support
            app.UseMvc(routes =>
            {
                //customize the rouite
                routes.MapRoute(
                  name: "categoryfilter",
                  template: "Pie/{action}/{category?}",
                  defaults: new { Controller = "Pie", action = "List" }); // here , category is parameter , coming frm 

                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");


            });
            //inject data seed to DB
            DbInitializer.Seed(app);

        }
    }
}
