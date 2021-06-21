using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LezizTariflerSepeti.Business.RepositoryInterfaces;
using LezizTariflerSepeti.Business.RepositoryServices;
using LezizTariflerSepeti.Business.UnıtOfWork;
using LezizTariflerSepeti.Data;
using LezizTariflerSepeti.Entity.Models;
using LezizTariflerSepeti.Root;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LezizTariflerSepeti.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {


            services.AddControllersWithViews();
            CompositionRoot.InjectDependencies(services);
            services.AddRazorPages();
            services.AddIdentity<MyUser, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders(); 

            
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
