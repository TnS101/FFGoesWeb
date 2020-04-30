using Application.CQ.Users.Feedbacks.Command;
using Application.Tests.Infrastructure;
using Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Users.Feedbacks
{
    public class SendFeedbackCommandHandlerTests : CommandTestBase
    {
        private readonly SendFeedbackCommandHandler sut;

        public SendFeedbackCommandHandlerTests()
        {
            this.sut = new SendFeedbackCommandHandler(context);
            CommandArrangeHelper.GetUserId(context);
        }

        [Fact]
        public async Task ShouldSendFeedback()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new SendFeedbackCommand 
            {
                Content = "Something",
                Rate = 1,
                UserId = "1",
            }, CancellationToken.None));

            var feedBack = this.context.Feedbacks.Find(1);

            var user = await this.context.AppUsers.FindAsync("1");

            feedBack.Id.ShouldBe(1);
            feedBack.Content.ShouldBe("Something");
            feedBack.Rate.ShouldBe(1);
            feedBack.UserId.ShouldBe("1");

            status.Status.ToString().ShouldBe(GConst.SuccessStatus);

            status.Result.ShouldBe(GConst.SuccesfulFeedbackRedirect);
        }
    }
}
