using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project_DDD.ApplicationLayer.AutoMapper;
using Project_DDD.DomainLayer.Entities.Concrete;
using Project_DDD.InfrastructureLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DDD.PresentationLayer
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
            services.AddControllersWithViews()
            .AddNewtonsoftJson()
                .AddFluentValidation();

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(ProjectProfile));

            services.AddIdentity<AppUsers, AppUserRoles>(x =>
            {
                x.SignIn.RequireConfirmedPhoneNumber = false;
                x.SignIn.RequireConfirmedEmail = false;
                x.SignIn.RequireConfirmedAccount = false;
                x.User.RequireUniqueEmail = true;
                x.Password.RequiredLength = 3;
                x.Password.RequireDigit = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequiredUniqueChars = 0;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
