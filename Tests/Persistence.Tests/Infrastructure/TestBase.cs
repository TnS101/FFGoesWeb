namespace Persistence.Tests.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Persistence.Context;
    using System;

    public class TestBase
    {
        public FFDbContext GetDbContext()
        {
            var builder = new DbContextOptionsBuilder<FFDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            var dbContext = new FFDbContext(builder.Options);

            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
