namespace Application.Tests.CQ.Admin.GameContent.Items.Commands
{
    using Application.CQ.Admin.GameContent.Items.Commands.Delete;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class DeleteItemCommandHandlerTests : CommandTestBase
    {
        private readonly int itemId;
        private readonly DeleteItemCommandHandler sut;

        public DeleteItemCommandHandlerTests()
        {
            this.sut = new DeleteItemCommandHandler(context);
            this.itemId = CommandArrangeHelper.GetToolId(context);
        }

        [Fact]
        public async Task ShouldDeleteItem()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new DeleteItemCommand { ItemId = $"{this.itemId}", Slot = "Tool" }, CancellationToken.None));

            status.Status.ToString().ShouldBe(GConst.SuccessStatus);
            status.Result.ToString().ShouldBe(string.Format(GConst.AdminItemCommandRedirect, "Tool"));
        }
    }
}
