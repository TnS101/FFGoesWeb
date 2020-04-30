using Application.CQ.Social.Likes.Commands.Create;
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

namespace Application.Tests.CQ.Social.Likes.Commands
{
    public class LeaveLikeCommandHandlerTests : CommandTestBase
    {
        private readonly LeaveLikeCommandHandler sut;

        public LeaveLikeCommandHandlerTests()
        {
            QueryArrangeHelper.AddUsers(context);
            CommandArrangeHelper.GetTopicId(context);
            CommandArrangeHelper.GetCommentId(context);
            this.sut = new LeaveLikeCommandHandler(context);
        }

        [Fact]
        public async Task ShouldLeaveLikes()
        {
            var result = await this.sut.Handle(new LeaveLikeCommand { TopicId = "1", UserId = "1" }, CancellationToken.None);

            result.ShouldBe(GConst.ErrorRedirect);

            context.Likes.Count().ShouldBe(0);

            var result2 = await this.sut.Handle(new LeaveLikeCommand { CommentId = "1", UserId = "1" }, CancellationToken.None);

            result2.ShouldBe(GConst.ErrorRedirect);

            context.Likes.Count().ShouldBe(0);

            QueryArrangeHelper.AddLikes(context);

            var result3 = await this.sut.Handle(new LeaveLikeCommand { TopicId = "1", UserId = "1" }, CancellationToken.None);

            result3.ShouldBe(GConst.ErrorRedirect);

            var result4 = await this.sut.Handle(new LeaveLikeCommand { CommentId = "1", UserId = "1" }, CancellationToken.None);

            result4.ShouldBe(GConst.ErrorRedirect);
        }
    }
}
