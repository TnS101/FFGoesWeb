namespace WebUI
{
    using System;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.Common.Mappings;
    using AutoMapper;
    using Domain.Entities.Common;
    using Domain.Models;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Net.Http.Headers;
    using Persistence.Context;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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
            var assembly = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(assembly);

            // Database
            services.AddDbContextPool<FFDbContext>(opt => opt.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")))
                .AddScoped<IFFDbContext, FFDbContext>();

            // Identity
            services.AddDefaultIdentity<AppUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
            })
            .AddSignInManager()
            .AddDefaultTokenProviders()
            .AddDefaultUI()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<FFDbContext>();

            // Authorization
            services.AddAuthorization();

            // Other services
            services.AddSignalR();
            services.AddMemoryCache();
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            services.AddResponseCaching();
            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Hourly", new CacheProfile()
                {
                    Duration = 60 * 60,
                });
                options.CacheProfiles.Add("Weekly", new CacheProfile()
                {
                    Duration = 60 * 60 * 24 * 7,
                });
            });

            // Cookies
            services.Configure<CookiePolicyOptions>(
               options =>
               {
                   options.CheckConsentNeeded = context => true;
                   options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
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
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = (context) =>
                {
                    var headers = context.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromDays(365),
                    };
                },
            });

            app.UseResponseCaching();
            app.UseHttpsRedirection();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

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
