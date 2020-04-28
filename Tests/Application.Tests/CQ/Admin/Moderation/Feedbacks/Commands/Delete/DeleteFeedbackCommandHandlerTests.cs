namespace Application.Tests.CQ.Admin.Moderation.Feedbacks.Commands.Delete
{
    using Application.CQ.Admin.Moderation.Feedbacks.Commands.Delete.DeleteFeedbackCommand;
    using Application.Tests.Infrastructure;
    using global::Common;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class DeleteFeedbackCommandHandlerTests : CommandTestBase
    {
        private int feedbackId;
        private DeleteFeedbackCommandHandler sut;

        public DeleteFeedbackCommandHandlerTests()
        {
            this.feedbackId = CommandArrangeHelper.GetFeedbackId(context);
            this.sut = new DeleteFeedbackCommandHandler(context);
        }

        [Fact]
        public async Task ShouldDeleteFeedback()
        {
            var status = Task<string>.FromResult(await sut.Handle(new DeleteFeedbackCommand { FeedbackId = this.feedbackId }, CancellationToken.None));

            Assert.Equal(GConst.SuccessStatus, status.Status.ToString());
            Assert.Equal(GConst.AdminFeedbackCommandRedirect, status.Result.ToString());
            Assert.Equal(0, this.context.Feedbacks.Count());
        }
    }
}
