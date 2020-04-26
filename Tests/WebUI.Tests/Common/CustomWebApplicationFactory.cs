namespace WebUI.Tests.Common
{
    using System;
    using Application.Common.Interfaces;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Persistence.Context;

    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        public static readonly InMemoryDatabaseRoot InMemoryDatabaseRoot = new InMemoryDatabaseRoot();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<IFFDbContext, FFDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting" + Guid.NewGuid().ToString(), InMemoryDatabaseRoot);
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<IFFDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    var concreteContext = (FFDbContext)context;

                    concreteContext.Database.EnsureCreated();

                    try
                    {
                        Utilities.InitializeDbForTests(concreteContext);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the " +
                                            "database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
}
