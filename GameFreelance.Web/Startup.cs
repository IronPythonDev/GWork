using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GameFreelance.Web
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration , IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public readonly IConfiguration Configuration;
        public readonly IWebHostEnvironment Environment;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            InitTransientServices(services);
            DataBaseAsyncInitialize(services);
            
            InitDbContext(services , Configuration , Environment);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(op =>
                {
                    op.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Auth");
                });
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
