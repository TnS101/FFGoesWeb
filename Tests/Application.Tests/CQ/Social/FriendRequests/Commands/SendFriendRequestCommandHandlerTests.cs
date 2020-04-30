using Application.CQ.Social.FriendRequests.Commands.Create;
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
    public class SendFriendRequestCommandHandlerTests : CommandTestBase
    {
        private readonly SendFriendRequestCommandHandler sut;

        public SendFriendRequestCommandHandlerTests()
        {
            QueryArrangeHelper.AddUsers(context);
            this.sut = new SendFriendRequestCommandHandler(context, userManager);
        }

        [Fact]
        public async Task ShoudlSendFriendRequest()
        {
            var result = await this.sut.Handle(new SendFriendRequestCommand { UserId = "1", RecieverId = "2" }, CancellationToken.None);

            result.ShouldBe(GConst.FriendCommandRedirect);

            context.FriendRequests.Count().ShouldBe(1);
        }
    }
}
