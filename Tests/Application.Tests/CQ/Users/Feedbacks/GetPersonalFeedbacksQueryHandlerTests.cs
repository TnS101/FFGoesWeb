using Application.CQ.Users.Feedbacks.Queries;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Users.Queries
{
    public class GetPersonalFeedbacksQueryHandlerTests : QueryTestFixture
    {
        private readonly GetPersonalFeedbacksQueryHandler sut;

        public GetPersonalFeedbacksQueryHandlerTests()
        {
            CommandArrangeHelper.GetUserId(context);
            QueryArrangeHelper.AddFeedbacks(context);
            this.sut = new GetPersonalFeedbacksQueryHandler(context, mapper);
        }

        [Fact]
        public async Task ShouldReturnPersonalFeedbacks()
        {
            var result = await this.sut.Handle(new GetPersonalFeedbacksQuery { UserId = "1" }, CancellationToken.None);

            result.ShouldBeOfType<FeedbackListViewModel>();

            result.Feedbacks.Count().ShouldBe(3);

            int counter = 1;

            foreach (var feedback in result.Feedbacks)
            {
                feedback.Id.ShouldBe(counter);
                feedback.IsAccepted.ShouldBeFalse();
                feedback.Rate.ShouldBe(0);
                feedback.Stars.ShouldBe(0);
                feedback.SentOn.ShouldNotBeNull();
                feedback.Content.ShouldBe("sewew");

                counter++;
            }
        }
    }
}
