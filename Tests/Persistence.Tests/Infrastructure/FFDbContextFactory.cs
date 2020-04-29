namespace Persistence.Tests.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Persistence.Context;
    using System;

    public class FFDbContextFactory
    {
        public static FFDbContext Create()
        {
            var options = new DbContextOptionsBuilder<FFDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new FFDbContext(options);

            context.Database.EnsureCreated();

            return context;
        }

        public static void Delete(FFDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
