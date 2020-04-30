using Application.CQ.Social.FriendRequests.Queries;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Social.FriendRequests.Queries
{
    public class GetPersonalFriendRequestsQueryHandlerTests : QueryTestFixture
    {
        private readonly GetPersonalFriendRequestsQueryHandler sut;

        public GetPersonalFriendRequestsQueryHandlerTests()
        {
            this.sut = new GetPersonalFriendRequestsQueryHandler(context, mapper);
            CommandArrangeHelper.GetUserId(context);
            QueryArrangeHelper.AddFriendRequests(context);
        }

        [Fact]
        public async Task ShouldGetPersonalFriendRequests()
        {
            var result = await this.sut.Handle(new GetPersonalFriendRequestsQuery { UserId = "1" }, CancellationToken.None);

            result.ShouldBeOfType<FriendRequestListViewModel>();
            result.FriendRequests.Count().ShouldBe(2);
            context.FriendRequests.Count().ShouldBe(3);
        }
    }
}
