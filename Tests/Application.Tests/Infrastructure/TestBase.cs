namespace Application.Tests.Infrastructure
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Persistence.Context;

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
