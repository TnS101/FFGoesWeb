using Application.CQ.Social.Friends.Commands.Delete;
using Application.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Tests.CQ.Social.Friends.Commands
{
    public class RemoveFriendCommandHandlerTests : CommandTestBase
    {
        private readonly RemoveFriendCommandHandler sut;

        public RemoveFriendCommandHandlerTests()
        {
            this.sut = new RemoveFriendCommandHandler(context);
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
