using Application.CQ.Social.Messages.Commands.Create;
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

namespace Application.Tests.CQ.Social.Messages.Commands
{
    public class DeleteMessageCommandHandlerTests : CommandTestBase
    {
        private readonly string messageId;
        private readonly DeleteMessageCommandHandler sut;

        public DeleteMessageCommandHandlerTests()
        {
            this.sut = new DeleteMessageCommandHandler(context);
            this.messageId = CommandArrangeHelper.GetMessageId(context);
        }

        [Fact]
        public async Task ShouldDeleteMessage()
        {
            var result = await this.sut.Handle(new DeleteMessageCommand { MessageId = this.messageId }, CancellationToken.None);

            result.ShouldBe(GConst.MessageCommandRedirect);
            this.context.Messages.Count().ShouldBe(0);
        }
    }
}
