namespace Application.Tests.CQ.Admin.Moderation.Feedbacks.Queries.ToDoList
{
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery.ToDoList;
    using Application.Tests.Infrastructure;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class ToDoListHandlerTests : QueryTestFixture
    {
        private ToDoListHandler sut;

        public ToDoListHandlerTests()
        {
            QueryArrangeHelper.AddFeedbacks(this.context);
            sut = new ToDoListHandler(context, mapper);
        }

        [Fact]
        public async Task GetTodoListHandlerTets()
        {
            var status = await this.sut.Handle(new ToDoList { }, CancellationToken.None);

            status.ShouldBeOfType<FeedbackTaskListViewModel>();
            status.Tasks.Count().ShouldBe(0);
        }
    }
}
