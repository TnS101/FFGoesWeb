using Application.CQ.Users.Statuses.Queries;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Users.Statuses.Queries
{
    public class GetAllStatusesQueryHandlerТеsts : QueryTestFixture
    {
        private readonly GetAllStatusesQueryHandler sut;

        public GetAllStatusesQueryHandlerТеsts()
        {
            this.sut = new GetAllStatusesQueryHandler(context, mapper);
            QueryArrangeHelper.AddStatuses(context);
        }

        [Fact]
        public async Task ShoudlGetCurrentComment()
        {
            var result = await this.sut.Handle(new GetAllStatusesQuery { }, CancellationToken.None);
            result.ShouldBeOfType<StatusListViewModel>();
            result.Statuses.Count().ShouldBe(4);

            int counter = 1;
            foreach (var status in result.Statuses)
            {
                status.Id.ShouldBe(counter);
                status.IClass.ShouldBe("1");
                status.DisplayName.ShouldBe("1");
                counter++;
            }
        }
    }
}
