using Application.CQ.Social.Likes.Commands.Delete;
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
    public class DislikeCommandHandlerTests : CommandTestBase
    {
        private readonly DislikeCommandHandler sut;

        public DislikeCommandHandlerTests()
        {
            QueryArrangeHelper.AddUsers(context);
            CommandArrangeHelper.GetTopicId(context);
            CommandArrangeHelper.GetCommentId(context);
            QueryArrangeHelper.AddLikes(context);
            this.sut = new DislikeCommandHandler(context);
        }

        [Fact]
        public async Task ShouldRemoveLikes()
        {
            var result = await this.sut.Handle(new DislikeCommand { TopicId = "1", UserId = "1" }, CancellationToken.None);

            result.ShouldBe(@"\Error\Default");

            context.Likes.Count().ShouldBe(4);

            var result2 = await this.sut.Handle(new DislikeCommand { CommentId = "1", UserId = "1" }, CancellationToken.None);

            result2.ShouldBe(@"\Error\Default");

            context.Likes.Count().ShouldBe(4);

            var result3 = await this.sut.Handle(new DislikeCommand { TopicId = "1", UserId = "1" }, CancellationToken.None);

            result3.ShouldBe(@"\Error\Default");

            var result4 = await this.sut.Handle(new DislikeCommand { CommentId = "1", UserId = "1" }, CancellationToken.None);

            result4.ShouldBe(@"\Error\Default");
        }
    }
}
