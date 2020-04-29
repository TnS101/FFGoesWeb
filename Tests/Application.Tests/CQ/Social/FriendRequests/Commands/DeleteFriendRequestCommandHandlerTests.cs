using Application.CQ.Social.FriendRequests.Commands.Delete;
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
    public class DeleteFriendRequestCommandHandlerTests : CommandTestBase
    {
        private readonly int friendRequestId;
        private readonly DeleteFriendRequestCommandHandler sut;

        public DeleteFriendRequestCommandHandlerTests()
        {
            this.sut = new DeleteFriendRequestCommandHandler(context);
            this.friendRequestId = CommandArrangeHelper.GetFriendRequestId(context);
        }

        [Fact]
        public async Task ShouldDeleteFriendRequest()
        {
            string content = "newcontent";

            var result = await this.sut.Handle(new DeleteFriendRequestCommand { RequestId = this.friendRequestId }, CancellationToken.None);

            result.ShouldBe(string.Format(GConst.FriendCommandRedirect));
            this.context.FriendRequests.Count().ShouldBe(0);
        }
    }
}
