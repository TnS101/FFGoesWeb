namespace Application.Tests.Infrastructure
{
    using Domain.Entities.Common;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using Persistence.Context;
    using System;
    using System.Security.Claims;

    public class CommandTestBase : IDisposable
    {
        protected readonly FFDbContext context;
        protected readonly UserManager<AppUser> userManager;

        public CommandTestBase()
        {
            this.userManager = this.GetMockUserManager().Object;
            this.context = FFDbContextFactory.Create();
        }

        public void Dispose()
        {
            FFDbContextFactory.Delete(this.context);
        }

        public class TestPrincipal : ClaimsPrincipal
        {
            public TestPrincipal(params Claim[] claims) : base(new TestIdentity(claims))
            {
            }
        }

        public class TestIdentity : ClaimsIdentity
        {
            public TestIdentity(params Claim[] claims) : base(claims)
            {
            }
        }

        private Mock<UserManager<AppUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<AppUser>>();
            return new Mock<UserManager<AppUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }
    }
}
