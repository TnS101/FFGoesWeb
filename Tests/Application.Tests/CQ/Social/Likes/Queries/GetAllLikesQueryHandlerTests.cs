using Application.CQ.Social.Likes.Queries;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Social.Likes.Queries
{
    public class GetAllLikesQueryHandlerTests : QueryTestFixture
    {
        private readonly GetAllLikesQueryHandler sut;

        public GetAllLikesQueryHandlerTests()
        {
            QueryArrangeHelper.AddUsers(context);
            QueryArrangeHelper.AddLikes(context);
            CommandArrangeHelper.GetTopicId(context);
            CommandArrangeHelper.GetCommentId(context);
            this.sut = new GetAllLikesQueryHandler(context, mapper);
        }

        [Fact]
        public async Task ShouldGetLikes()
        {
            var result = await this.sut.Handle(new GetAllLikesQuery { TopicId = "1" }, CancellationToken.None);

            result.ShouldBeOfType<LikesListViewModel>();

            result.Likes.Count().ShouldBe(4);

            foreach (var like in result.Likes)
            {
                like.CommentId.ShouldBe("1");
                like.TopicId.ShouldBe("1");
                like.UserId.ShouldBe("1");
            }

            var result1 = await this.sut.Handle(new GetAllLikesQuery { CommentId = "1" }, CancellationToken.None);

            result1.ShouldBeOfType<LikesListViewModel>();

            foreach (var like in result1.Likes)
            {
                like.CommentId.ShouldBe("1");
                like.TopicId.ShouldBe("1");
                like.UserId.ShouldBe("1");
            }
        }
    }
}
