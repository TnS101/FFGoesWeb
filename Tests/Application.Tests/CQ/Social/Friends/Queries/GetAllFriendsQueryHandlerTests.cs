using Application.CQ.Social.Friends.Queries.GetAllFriendsQuery;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Social.Friends.Queries
{
    public class GetAllFriendsQueryHandlerTests : QueryTestFixture
    {
        private readonly GetAllFriendsQueryHandler sut;

        public GetAllFriendsQueryHandlerTests()
        {
            QueryArrangeHelper.AddUsers(context);
            this.sut = new GetAllFriendsQueryHandler(context);
            QueryArrangeHelper.AddFriends(context);
        }

        [Fact]
        public async Task ShouldGetAllFriends()
        {
            var result = await this.sut.Handle(new GetAllFriendsQuery { UserId = "1" }, CancellationToken.None);

            result.ShouldBeOfType<UserListViewModel>();

            result.Users.Count().ShouldBe(1);

            foreach (var user in result.Users)
            {
                user.Id.ShouldBe("2");
                user.MasteryPoints.ShouldBe(0);
                user.UserName.ShouldNotBeNull();
            }
        }
    }
}
