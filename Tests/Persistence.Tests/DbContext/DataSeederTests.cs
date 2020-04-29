using Persistence.Context;
using Persistence.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Persistence.Tests.DbContext
{
    public class DataSeederTests : CommandTestBase
    {
        private readonly DataSeeder dataSeeder;

        public DataSeederTests()
        {
            this.dataSeeder = new DataSeeder();
        }

        [Fact]
        public async Task ShouldSeedData()
        {
            await this.dataSeeder.SeedAsync(context, CancellationToken.None);

            context.AppUsers.Count().ShouldBe(1);
        }
    }
}
