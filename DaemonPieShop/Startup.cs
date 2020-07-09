using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaemonPieShop.Data.DbContexts;
using DaemonPieShop.Data.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DaemonPieShop.Data.Services;
using DaemonPieShop.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace DaemonPieShop
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
            services.AddDbContextPool<DaemonPieShopDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<DaemonPieShopDbContext>();

            services.AddScoped<IPieRepository, PieServices>();
            services.AddScoped<ICategoryRepository, CategoryService>();
            services.AddScoped<IOrderRepository, OrderService>();
            services.AddScoped<ShoppingCart>(x=>ShoppingCart.GetCart(x)); //ability to check if cartId already on session or if not then to pass one
            //services.AddTransient(); //
            //services.AddSingleton();
            services.AddHttpContextAccessor(); //for the http request which is used in session
            services.AddSession(); //same as http request  note: Also need to use miidle ware 
            services.AddControllersWithViews(); //ADDED

            //services.AddMvc();  //instead previous versions
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection(); //added
            app.UseStaticFiles();//ADDED
            app.UseSession(); //always add it before routing

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}");
                endpoints.MapRazorPages();
                //commented section
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Daemon Pie Shop!");
                //});
            });
        }
    }
}
