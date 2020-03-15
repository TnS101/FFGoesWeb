namespace WebUI
{
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup()
        {
        }

        public void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();
            services.AddMediatR(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
                app.UseCookiePolicy();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                     "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
