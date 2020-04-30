using Application.CQ.Social.FriendRequests.Commands.Update;
using Application.Tests.Infrastructure;
using Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Social.FriendRequests.Commands
{
    public class AcceptFriendRequestCommandHandlerTests : CommandTestBase
    {
        private readonly AcceptFriendRequestCommandHandler sut;

        public AcceptFriendRequestCommandHandlerTests()
        {
            this.sut = new AcceptFriendRequestCommandHandler(context);
            QueryArrangeHelper.AddFriendRequests(context);
            QueryArrangeHelper.AddUsers(context);
            QueryArrangeHelper.AddFriends(context);
        }

        [Fact]
        public async Task ShouldAcceptFriendRequest()
        {
            var result = await this.sut.Handle(new AcceptFriendRequestCommand { RequestId = 1, UserId = "1",  }, CancellationToken.None);

            result.ShouldBe(string.Format(GConst.FriendCommandRedirect));
            this.context.FriendRequests.Count().ShouldBe(0);
            this.context.Friends.Count().ShouldBe(2);
        }
    }
}
