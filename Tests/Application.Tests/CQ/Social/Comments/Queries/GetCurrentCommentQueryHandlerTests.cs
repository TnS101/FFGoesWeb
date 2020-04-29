using Application.CQ.Social.Comments.Queries.GetCurrentCommentQuery;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Social.Comments.Queries
{
    public class GetCurrentCommentQueryHandlerTests : QueryTestFixture
    {
        private readonly string commentId;
        private readonly GetCurrentCommentQueryHandler sut;

        public GetCurrentCommentQueryHandlerTests()
        {
            this.sut = new GetCurrentCommentQueryHandler(context, mapper);
            this.commentId = CommandArrangeHelper.GetCommentId(context);
        }

        [Fact]
        public async Task ShoudlGetCurrentComment()
        {
            var status = await this.sut.Handle(new GetCurrentCommentQuery { CommentId = commentId }, CancellationToken.None);
            status.ShouldBeOfType<CommentMinViewModel>();
        }
    }
}
