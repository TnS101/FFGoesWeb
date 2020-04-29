using Application.CQ.Social.Comments.Commands.Create;
using Application.Tests.Infrastructure;
using Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Social.Comments.Commands
{
    public class EditCommentCommandHandlerTests : CommandTestBase
    {
        private readonly string commentId;
        private readonly EditCommentCommandHandler sut;

        public EditCommentCommandHandlerTests()
        {
            this.sut = new EditCommentCommandHandler(context);
            this.commentId = CommandArrangeHelper.GetCommentId(context);
        }

        [Fact]
        public async Task ShouldUpdateComment()
        {
            string content = "newcontent";

            var result = await this.sut.Handle(new EditCommentCommand { CommentId = this.commentId, Content = content }, CancellationToken.None);

            result.ShouldBe(string.Format(GConst.CommentCommandRedirect, "1"));
        }
    }
}
