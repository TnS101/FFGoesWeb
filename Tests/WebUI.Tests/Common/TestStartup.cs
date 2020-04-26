namespace WebUI.Tests.Common
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence.Context;

    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration)
             : base(configuration)
        {
        }

        public async Task SetUpDataBase(IServiceCollection services)
        {
            services
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<FFDbContext>(options =>
               options.UseInMemoryDatabase("MyTestDatabase"));

            await this.SeedData(services);
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            this.ConfigureServices(services);
        }

        private async Task SeedData(IServiceCollection services)
        {
            using (var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<FFDbContext>())
                {
                    await DataSeeder.Seed(context);
                }
            }
        }
    }
}
