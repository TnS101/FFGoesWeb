namespace WebUI
{
    using Application.Common.Handlers;
    using Application.Common.Mappings;
    using AutoMapper;
    using Domain.Entities.Common;
    using Domain.Models;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Persistence;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup()
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(typeof(Startup));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // MediatR
            services.AddMediatR(typeof(Startup));
            var registerHandlers = new RegisterHandlers(services);

            // Identity
            // services.AddIdentityCore<AppUser>();

            // Database
            services.AddDbContext<FFDbContext>()
                .AddTransient<IFFDbContext, FFDbContext>();

            services.AddIdentity<AppUser, ApplicationRole>()
                .AddDefaultTokenProviders()
                .AddDefaultUI()
               .AddEntityFrameworkStores<FFDbContext>();

            // Other services
            services.AddSignalR();
            services.AddControllers();
            services.AddMvc();

            // Cookies
            services.Configure<CookiePolicyOptions>(
               options =>
               {
                   options.CheckConsentNeeded = context => true;
                   options.MinimumSameSitePolicy = SameSiteMode.None;
               });
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

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
