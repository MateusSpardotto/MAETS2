using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Impl;
using BLL.Interfaces;
using DAO;
using DAO.Impl;
using DAO.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MAETS
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
            services.AddDbContextPool<MContext>(options => options.UseSqlServer(this.Configuration["ConnectionStrings"]));

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<IDesenvolvedorService, DesenvolvedorService>();
            services.AddTransient<IDesenvolvedorRepository, DesenvolvedorRepository>();

            services.AddTransient<IGeneroService, GeneroService>();
            services.AddTransient<IGeneroRepository, GeneroRepository>();

            services.AddTransient<IJogoService, JogoService>();
            services.AddTransient<IJogoRepository, JogoRepository>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Usuario/Login";
                options.LogoutPath = "/Account/LogOff";
                options.Cookie.Name = "AshProgHelpCookie";
            });
            services.AddMvc();
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

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
