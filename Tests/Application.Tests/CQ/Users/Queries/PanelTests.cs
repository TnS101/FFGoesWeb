using Application.CQ.Users.Queries.Panel;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Users.Queries
{
    public class PanelTests : QueryTestFixture
    {
        private readonly UserPanelQueryHandler sut;

        public PanelTests()
        {
            QueryArrangeHelper.AddUsers(context);
            CommandArrangeHelper.GetFeedbackId(context);
            CommandArrangeHelper.GetFriendId(context);
            CommandArrangeHelper.GetStatusId(context);
            CommandArrangeHelper.GetCommentId(context);
            CommandArrangeHelper.GetUserStatusIds(context);
            CommandArrangeHelper.GetTopicId(context);
            CommandArrangeHelper.GetHeroId(context);
            this.sut = new UserPanelQueryHandler(context);
        } 

        [Fact]
        public async Task PanelShouldBeHandledProperly()
        {
            var result = await this.sut.Handle(new UserPanelQuery { UserId = "1" }, CancellationToken.None);

            result.StatusIClass.ShouldBe("asdasd");
            result.UserName.ShouldBe("username");
            result.MasteryPoints.ShouldBe(0);
            result.ForumPoints.ShouldBe(0);
            result.Friends.ShouldBe(0);
            result.Stars.ShouldBe(0);
            result.LastFeedbackSentOn.ShouldBeNull();
            result.Topics.ShouldBe(1);
            result.Units.ShouldBe(1);
            result.Warnings.ShouldBe(0);

            QueryArrangeHelper.AddLikes(context);

            var result2 = await this.sut.Handle(new UserPanelQuery { UserId = "1" }, CancellationToken.None);

            result2.StatusIClass.ShouldBe("asdasd");
            result2.UserName.ShouldBe("username");
            result2.MasteryPoints.ShouldBe(0);
            result2.ForumPoints.ShouldBe(8);
            result2.Friends.ShouldBe(0);
            result2.Stars.ShouldBe(0);
            result2.LastFeedbackSentOn.ShouldBeNull();
            result2.Topics.ShouldBe(1);
            result2.Units.ShouldBe(1);
            result2.Warnings.ShouldBe(0);
        }
    }
}
