namespace Application.Tests.CQ.Admin.Moderation.Feedbacks.Commands.Delete
{
    using Application.CQ.Admin.Moderation.Feedback.Commands.Delete.FeedbackTaskDoneCommand;
    using Application.Tests.Infrastructure;
    using global::Common;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class FeedbackTaskDoneCommandHandlerTests : CommandTestBase
    {
        private readonly int feedbackId;
        private readonly FeedbackTaskDoneCommandHandler sut;

        public FeedbackTaskDoneCommandHandlerTests()
        {
            this.feedbackId = CommandArrangeHelper.GetFeedbackId(this.context);
            this.sut = new FeedbackTaskDoneCommandHandler(this.context);
        }

        [Fact]
        public async Task ShouldFinishFeedbackTask()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new FeedbackTaskDoneCommand { FeedbackId = this.feedbackId }, CancellationToken.None));

            Assert.Equal(GConst.SuccessStatus, status.Status.ToString());
            Assert.Equal(GConst.AdminToDoListRedirect, status.Result.ToString());
            Assert.Equal(0, this.context.Feedbacks.Count());
        }
    }
}
