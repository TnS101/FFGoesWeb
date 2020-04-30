namespace Application.Tests.CQ.Admin.Moderation.Feedbacks.Commands.Update
{
    using Application.CQ.Admin.Moderation.Feedbacks.Commands.Update;
    using Application.Tests.Infrastructure;
    using global::Common;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class AcceptFeedbackCommandHandlerTests : CommandTestBase
    {
        private readonly AcceptFeedbackCommandHandler sut;

        public AcceptFeedbackCommandHandlerTests()
        {
            this.sut = new AcceptFeedbackCommandHandler(context);
            QueryArrangeHelper.AddFeedbacks(context);
            CommandArrangeHelper.GetUserId(context);
        }

        [Fact]
        public async Task ShouldAcceptFeedback()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new AcceptFeedbackCommand { FeedbackId = 1, Stars = 1 }, CancellationToken.None));

            var feedBack = this.context.Feedbacks.Find(1);

            var user = await this.context.AppUsers.FindAsync("1");

            Assert.Equal(GConst.SuccessStatus, status.Status.ToString());
            Assert.Equal(1, this.context.Notifications.Count());
            Assert.Equal(GConst.AdminFeedbackCommandRedirect, status.Result.ToString());
            Assert.True(feedBack.IsAccepted);
            Assert.Equal(1, feedBack.Stars);
            Assert.Equal(1, user.Stars);
        }
    }
}
