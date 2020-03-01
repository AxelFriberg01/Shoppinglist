using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingList.Models;
using ShoppingList.Models.Entities;

namespace ShoppingList
{
    
    //Release branch

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ShoppingCartContext>(o => o.UseSqlServer(connString));
            services.AddTransient<ProductsService>();
            //services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddControllersWithViews(
            //    o =>
            //{
            //    o.Filters.Add(
            //        new AutoValidateAntiforgeryTokenAttribute());
            //}
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/error/exception");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            var cultureInfo = new CultureInfo("sv-SE");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
            //{
            //    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
