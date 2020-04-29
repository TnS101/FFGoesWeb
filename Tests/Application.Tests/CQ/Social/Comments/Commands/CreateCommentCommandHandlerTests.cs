namespace Application.Tests.CQ.Social.Comments.Commands
{
    using Application.CQ.Social.Comments.Commands.Create;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    using System.Security.Claims;
    using WebUI.Controllers.Social;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;

    public class CreateCommentCommandHandlerTests : CommandTestBase
    {
        private readonly string topicId;
        private readonly CreateCommentCommandHandler sut;

        public CreateCommentCommandHandlerTests()
        {
            this.sut = new CreateCommentCommandHandler(context, this.userManager);
            this.topicId = CommandArrangeHelper.GetTopicId(context);
        }

        [Fact]
        public async Task ShouldCreateComment()
        {
            await CommandArrangeHelper.GetUserId(context);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, "1"),
                                        new Claim(ClaimTypes.Name, "validname"),
                                        new Claim(ClaimTypes.Role, "User"),
                                        new Claim("AspNet.Identity.SecurityStamp", "2"),
                                        new Claim("amr", "pwd")
                                         }, "Identity.Application"));

            var status = Task<string>.FromResult(await this.sut.Handle(new CreateCommentCommand { TopicId = this.topicId, Content = "something", User = user }, CancellationToken.None));

            status.Status.ToString().ShouldBe(GConst.SuccessStatus);
            status.Result.ToString().ShouldBe(string.Format(GConst.CommentCommandRedirect, this.topicId));
            this.context.Comments.Count().ShouldBe(1);
        }
    }
}
