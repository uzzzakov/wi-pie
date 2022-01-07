using Khinkali.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Khinkali
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AccountContext>(options => options.UseSqlServer(connection));

            services.AddDistributedMemoryCache();
            services.AddMvc();
            services.AddSession(options =>
            {
                // chto ya pitalsya sdelat //
                options.IdleTimeout = TimeSpan.FromMinutes(1);
                /*options.IdleTimeout = TimeSpan.FromSeconds(10);*/
                /*options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;*/

                // tvoe rewenie - ne srabotalo (owibku dalo)//
                //options.Cookie.ApplicationCookie.ExpireTimeSpan = new TimeSpan(0, 0, 0);

                // tvoe ispravlenoe rewenie - ne rabotaet (owibku daet) //
                //options.Cookie.Expiration = new TimeSpan(0, 0, 10);  


            });

            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Bdro/Index");
                });
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
