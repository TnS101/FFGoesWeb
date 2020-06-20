namespace WebUI
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Domain.Entities.Common;
    using Domain.Models;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Persistence.Context;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<FFDbContext>();

                await SeedUsersAndRoles(services, context);
                await DataSeeder.Seed(context);

                //var counter = 12;

                //while (context.WeaponsInventories.Count() < 105)
                //{
                //    context.WeaponsInventories.Add(new Domain.Entities.Game.Items.ManyToMany.Inventories.WeaponInventory
                //    {
                //        WeaponId = counter,
                //        InventoryId = 6,
                //    });

                //    await context.SaveChangesAsync(CancellationToken.None);

                //    counter++;
                //}
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://192.168.0.102:5000/", "https://192.168.0.102:5001");
                });

        private static async Task SeedUsersAndRoles(IServiceProvider services, FFDbContext context)
        {
            var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

            var userManager = services.GetRequiredService<UserManager<AppUser>>();

            context.Database.EnsureCreated();

            if (context.AppUsers.Any())
            {
                return;
            }

            var admin = new AppUser
            {
                UserName = "admin",
                Email = "admin@admin.com",
            };

            var mod = new AppUser
            {
                UserName = "moderator",
                Email = "moderator@moderator.com",
            };

            await userManager.CreateAsync(admin, "Admin@123456");

            await userManager.CreateAsync(mod, "Mod@123456");

            await roleManager.CreateAsync(new ApplicationRole(GConst.AdminRole));

            await roleManager.CreateAsync(new ApplicationRole(GConst.ModeratorRole));

            await roleManager.CreateAsync(new ApplicationRole(GConst.UserRole));

            await userManager.AddToRoleAsync(admin, GConst.AdminRole);

            await userManager.AddToRoleAsync(mod, GConst.ModeratorRole);

            await context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
