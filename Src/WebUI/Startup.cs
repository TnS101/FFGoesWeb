namespace WebUI
{
    using Application.Common.Handlers;
    using Application.Common.Mappings;
    using AutoMapper;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Persistence;
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

        public void ConfigureServices(IServiceCollection services)
        {
            //AutoMapper
            services.AddAutoMapper(typeof(Startup));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //MediatR
            services.AddMediatR(typeof(Startup));
            var registerHandlers = new RegisterHandlers(services);

            //Identity
            services.AddDbContext<FFDbContext>()
                .AddTransient<IFFDbContext,FFDbContext>();
            services.AddAuthentication();
            services.AddIdentityCore<ApplicationUser>().AddEntityFrameworkStores<FFDbContext>();

            //Other services
            services.AddSignalR();
            services.AddControllers();
            services.AddMvc();
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
                endpoints.MapControllerRoute(name: "areaRoute",
                    pattern:"{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                     pattern:"{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
