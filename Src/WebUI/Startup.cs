namespace WebUI
{
    using Application.CQ.Users.Commands.Create;
    using Application.GameCQ.Image.Queries;
    using Application.GameCQ.Monster.Queries;
    using Application.SeedInitialData;
    using AutoMapper;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Persistence;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
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
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup));
            services.AddDbContext<FFDbContext>()
                .AddTransient<IUserStore<ApplicationUser>,FFDbContext>();
            services.AddSignalR();
            services.AddControllers();
            services.AddMvc();
            services.AddAuthentication();
            services.AddScoped<IRequestHandler<DataSeederCommand,Unit>,DataSeederCommandHandler>();
            services.AddScoped<IRequestHandler<GetFightingClassImagesQuery, ImageListViewModel>, GetFightingClassImagesQueryHandler>();
            services.AddScoped<IRequestHandler<GetMonstersImagesQuery, MonsterImageListViewModel>, GetMonstersImagesQueryHandler>();
            services.AddScoped<IRequestHandler<RegisterUserCommand,string[]>, RegisterUserCommandHandler>();
            services.AddIdentityCore<ApplicationUser>().AddEntityFrameworkStores<FFDbContext>();
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
                    name: "default",
                     "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
