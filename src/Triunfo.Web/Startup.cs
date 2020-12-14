using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Triunfo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Triunfo.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace Triunfo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<TriunfoDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("TriunfoConnection")));

            services.AddDbContext<AppIdentityDbContext>(options =>
                 options.UseMySQL(
                     Configuration.GetConnectionString("IdentityContextConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMvc();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var defaultDateCulture = "es-CO";
            var ci = new CultureInfo(defaultDateCulture);
            // Configure the Localization middleware
            IApplicationBuilder applicationBuilder = app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ci),
                SupportedCultures = new List<CultureInfo>
        {
            ci,
        },
                SupportedUICultures = new List<CultureInfo>
                {
                }
            }
            );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
