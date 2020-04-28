namespace Application.Tests.CQ.Admin.GameContent.Items.Commands
{
    using Application.CQ.Admin.GameContent.Items.Commands.Update;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class UpdateItemCommandHandlerTests : CommandTestBase
    {
        private UpdateItemCommandHandler sut;
        private readonly int itemId;

        public UpdateItemCommandHandlerTests()
        {
            this.sut = new UpdateItemCommandHandler(context);
            this.itemId = CommandArrangeHelper.GetMaterialId(context);
        }

        [Fact]
        public async Task ShouldUpdateItem()
        {
            var result = await this.sut.Handle(new UpdateItemCommand { Id = $"{this.itemId}", Slot = "Material" }, CancellationToken.None);

            result.ShouldBe(string.Format(GConst.AdminItemCommandRedirectId, this.itemId, "Material"));
        }
    }
}
