using Application.CQ.Social.Messages.Queries;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Social.Messages.Queries
{
    public class GetPersonalMessagesQueryHandlerTests : QueryTestFixture
    {
        private readonly GetPersonalMessagesQueryHandler sut;

        public GetPersonalMessagesQueryHandlerTests()
        {
            QueryArrangeHelper.AddUsers(context);
            QueryArrangeHelper.AddMessages(context);
            this.sut = new GetPersonalMessagesQueryHandler(context, mapper);
        }

        [Fact]
        public async Task ShouldReturnPersonalMessages()
        {
            var result = await this.sut.Handle(new GetPersonalMessagesQuery { UserId = "1", SenderId = "2" }, CancellationToken.None);

            result.ShouldBeOfType<MessageListViewModel>();

            result.Messages.Count().ShouldBe(0);

            foreach (var message in result.Messages)
            {
                message.SentOn.ShouldNotBeNull();
                message.Content.ShouldBe("sewew");
            }
        }
    }
}
