using Application.CQ.Users.Statuses.Commands.Update;
using Application.Tests.Infrastructure;
using Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Users.Statuses
{
    public class UpdateStatusCommandHandlerTests : CommandTestBase
    {
        private readonly UpdateStatusCommandHandler sut;

        public UpdateStatusCommandHandlerTests()
        {
            this.sut = new UpdateStatusCommandHandler(context);
            QueryArrangeHelper.AddStatuses(context);
            CommandArrangeHelper.GetUserStatusIds(context);
            CommandArrangeHelper.GetUserId(context);
        }

        [Fact]
        public async Task ShouldAcceptFeedback()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new UpdateStatusCommand { StatusId = 1, UserId = "1"}, CancellationToken.None));

            var userStatus = this.context.UserStatuses.FirstOrDefault();

            userStatus.StatusId.ShouldBe(1);
            userStatus.UserId.ShouldBe("1");

            status.Result.ShouldBe($"{GConst.ProfileRedirect}#statuses");

            var status1 = Task<string>.FromResult(await this.sut.Handle(new UpdateStatusCommand { StatusId = 0, UserId = "1" }, CancellationToken.None));

            status1.Result.ShouldBe($"{GConst.ProfileRedirect}#statuses");

            this.context.UserStatuses.Count().ShouldBe(1);
        }
    }
}
