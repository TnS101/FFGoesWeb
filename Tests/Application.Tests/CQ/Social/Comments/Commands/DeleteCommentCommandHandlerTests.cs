using Application.CQ.Social.Comments.Commands.Create;
using Application.Tests.Infrastructure;
using Common;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Social.Comments.Commands
{
    public class DeleteCommentCommandHandlerTests : CommandTestBase
    {
        private readonly DeleteCommentCommandHandler sut;

        public DeleteCommentCommandHandlerTests()
        {
            this.sut = new DeleteCommentCommandHandler(context);
            QueryArrangeHelper.AddComments(context);
        }

        [Fact]
        public async Task ShouldDeleteComment()
        {
            var result = await this.sut.Handle(new DeleteCommentCommand { CommentId = "1" }, CancellationToken.None);

            result.ShouldBe(string.Format(GConst.CommentCommandRedirect, "1"));
            this.context.Comments.Count().ShouldBe(2);
        }
    }
}
