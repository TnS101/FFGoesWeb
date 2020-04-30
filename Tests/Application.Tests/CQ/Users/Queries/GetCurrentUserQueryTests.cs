using Application.CQ.Users.Queries.GetCurrentUser;
using Application.Tests.Infrastructure;
using Domain.Entities.Social;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Users.Queries
{
    public class GetCurrentUserQueryTests : QueryTestFixture
    {
        private readonly GetCurrentUserQueryHandler sut;

        public GetCurrentUserQueryTests()
        {
            QueryArrangeHelper.AddUsers(context);
            this.sut = new GetCurrentUserQueryHandler(context, mapper);
        }

        [Fact]
        public async Task ShouldGetCurrentUser()
        {
            var result = await this.sut.Handle(new GetCurrentUserQuery { UserId = "1" }, CancellationToken.None);

            result.ForumPoints.ShouldBe(0);
            result.Friends.Count.ShouldBe(0);
            result.UserName.ShouldBe("username");
            result.MasteryPoints.ShouldBe(0);
        }
    }
}
