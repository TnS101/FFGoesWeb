using Application.CQ.Social.Messages.Commands.Create;
using Application.Tests.Infrastructure;
using Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Social.Messages.Commands
{
    public class EditMessageCommandHandlerTests : CommandTestBase
    {
        private readonly string messageId;
        private readonly EditMessageCommandHandler sut;

        public EditMessageCommandHandlerTests()
        {
            this.sut = new EditMessageCommandHandler(context);
            this.messageId = CommandArrangeHelper.GetMessageId(context);
        }

        [Fact]
        public async Task ShouldEditMessage()
        {
            string content = "newcontent";

            var result = await this.sut.Handle(new EditMessageCommand { MessageId = this.messageId, Content = content }, CancellationToken.None);

            result.ShouldBe(GConst.MessageCommandRedirect);
        }
    }
}
