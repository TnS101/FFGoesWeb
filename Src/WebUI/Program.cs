namespace WebUI
{
    using Application.SeedInitialData;
    using Common;
    using Domain.Entities.Common;
    using Domain.Models;
    using FinalFantasyTryoutGoesWeb.Persistence;
    using MediatR;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<FFDbContext>();

                //context.Database.EnsureCreated();
                //
                //var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
                //
                //var usermanager = services.GetRequiredService<UserManager<AppUser>>();
                //
                //await roleManager.CreateAsync(new ApplicationRole(GConst.AdminRole));
                //
                //await roleManager.CreateAsync(new ApplicationRole(GConst.UserRole));
                //
                //await roleManager.CreateAsync(new ApplicationRole(GConst.ModeratorRole));
                //var admin = new AppUser
                //{
                //    UserName = "admin",
                //    Email = "admin@admin.com",
                //};
                //
                //await usermanager.CreateAsync(admin, "Admin@123456");
                //
                //await usermanager.AddToRoleAsync(admin, GConst.AdminRole);
                //
                //context.SaveChanges();
                //
                //var mediator = services.GetRequiredService<IMediator>();
                //await mediator.Send(new DataSeederCommand());
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
