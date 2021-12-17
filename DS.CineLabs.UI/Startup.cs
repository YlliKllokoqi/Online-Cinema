using DS.CineLabs.Application;
using DS.CineLabs.Application.Payment;
using DS.CineLabs.Application.Validations;
using DS.CineLabs.Infrastructure;
using DS.CineLabs.Infrastructure.Identity;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DS.CineLabs.UI
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

            //services.AddControllersWithViews().AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddControllersWithViews();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<UserManager<AppUser>>();

            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
            });

            
        }
    }
}
