namespace Application.Tests.Infrastructure
{
    using System;
    using AutoMapper;
    using Persistence.Context;
    using Xunit;

    public class QueryTestFixture : IDisposable
    {
        protected FFDbContext context;
        protected IMapper mapper;

        public QueryTestFixture()
        {
            context = FFDbContextFactory.Create();
            mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            FFDbContextFactory.Delete(this.context);
        }
    }

    [CollectionDefinition("Queries")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
