using Application.CQ.Social.Notifications.Queries.GetPersonalNotificationsQuery;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Social.Notifications.Queries
{
    public class GetPersonalNotificationsQueryHandlerTests : QueryTestFixture
    {
        private readonly GetPersonalNotificationsQueryHandler sut;

        public GetPersonalNotificationsQueryHandlerTests()
        {
            QueryArrangeHelper.AddUsers(context);
            QueryArrangeHelper.AddNotifications(context);
            this.sut = new GetPersonalNotificationsQueryHandler(context, mapper);
        }

        [Fact]
        public async Task ShouldGetPersonalNotifications()
        {
            var result = await this.sut.Handle(new GetPersonalNotificationsQuery { UserId = "1" }, CancellationToken.None);

            result.ShouldBeOfType<NotificationListViewModel>();
            result.Notifications.Count().ShouldBe(4);

            foreach (var notification in result.Notifications)
            {
                notification.RecievedOn.ShouldNotBeNull();
                notification.Type.ShouldBe("NaiDobriqProekt");
                notification.ApplicationSection.ShouldBe("softuni");
                notification.Content.ShouldBe("me");
            }
        }
    }
}
