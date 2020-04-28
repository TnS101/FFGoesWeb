namespace Application.Tests.CQ.Admin.Moderation.Feedbacks.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery;
    using Application.Tests.Infrastructure;
    using Shouldly;
    using Xunit;

    public class GetAllFeedbacksQueryHandlerTests : QueryTestFixture
    {
        private GetAllFeedbacksQueryHandler sut;

        public GetAllFeedbacksQueryHandlerTests()
        {
            QueryArrangeHelper.AddFeedbacks(this.context);
            sut = new GetAllFeedbacksQueryHandler(context, mapper);
        }

        [Fact]
        public async Task GetAllFeedbacksQueryHandlerTest()
        {
            var status = await sut.Handle(new GetAllFeedbacksQuery { }, CancellationToken.None);

            status.ShouldBeOfType<FeedbacksListViewModel>();
            status.Feedbacks.Count().ShouldBe(3);
        }
    }
}
