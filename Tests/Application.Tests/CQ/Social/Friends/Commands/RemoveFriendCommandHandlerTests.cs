using Application.CQ.Social.Friends.Commands.Delete;
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

namespace Application.Tests.CQ.Social.Friends.Commands
{
    public class RemoveFriendCommandHandlerTests : CommandTestBase
    {
        private readonly RemoveFriendCommandHandler sut;

        public RemoveFriendCommandHandlerTests()
        {
            this.sut = new RemoveFriendCommandHandler(context);
            QueryArrangeHelper.AddFriends(context);
        }

        [Fact]
        public async Task ShouldDeleteFriendRequest()
        {
            var result = await this.sut.Handle(new RemoveFriendCommand { FriendId = "1", UserId = "1" }, CancellationToken.None);

            result.ShouldBe(string.Format(GConst.FriendCommandRedirect));
            this.context.Friends.Count().ShouldBe(0);
        }
    }
}
