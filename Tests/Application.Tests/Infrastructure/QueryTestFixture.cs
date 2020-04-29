namespace Application.Tests.Infrastructure
{
    using System;
    using System.Security.Claims;
    using AutoMapper;
    using Domain.Entities.Common;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using Persistence.Context;
    using Xunit;

    public class QueryTestFixture : IDisposable
    {
        protected FFDbContext context;
        protected IMapper mapper;
        protected UserManager<AppUser> userManager;

        public QueryTestFixture()
        {
            this.userManager = this.GetMockUserManager().Object;
            this.context = FFDbContextFactory.Create();
            this.mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            FFDbContextFactory.Delete(this.context);
        }

        

        private Mock<UserManager<AppUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<AppUser>>();
            return new Mock<UserManager<AppUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }
    }

    [CollectionDefinition("Queries")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
