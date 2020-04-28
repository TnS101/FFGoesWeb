namespace Application.Tests.CQ.Admin.GameContent.Items.Commands
{
    using Application.CQ.Admin.GameContent.Items.Commands.Create;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class CreateItemCommandHandlerTests : CommandTestBase
    {
        private readonly CreateItemCommandHandler sut;

        public CreateItemCommandHandlerTests()
        {
            this.sut = new CreateItemCommandHandler(context);
        }

        [Fact]
        public async Task ShouldCreateItem()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new CreateItemCommand { Slot = "Weapon" }, CancellationToken.None));

            status.Status.ToString().ShouldBe(GConst.SuccessStatus);
            this.context.Weapons.Count().ShouldBe(1);
        }
    }
}
