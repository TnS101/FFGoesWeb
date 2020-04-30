using Application.CQ.Users.Tickets.Commands.Create;
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

namespace Application.Tests.CQ.Users.Tickets
{
    public class OpenTicketCommandHandlerTests : CommandTestBase
    {
        private readonly OpenTicketCommandHandler sut;

        public OpenTicketCommandHandlerTests()
        {
            CommandArrangeHelper.GetUserId(context);
            CommandArrangeHelper.GetTopicId(context);
            CommandArrangeHelper.GetMessageId(context);
            CommandArrangeHelper.GetCommentId(context);
            this.sut = new OpenTicketCommandHandler(context);
        }

        [Fact]
        public async Task TicketShouldBeOpennedCorrectly()
        {
            await this.Result("Topic");

            await this.Result("Comment");

            await this.Result("Message");

            context.Tickets.Count().ShouldBe(3);
        } 

        private async Task Result(string contentType)
        {
            if (contentType == "Topic")
            {
                var topic = this.context.Topics.FirstOrDefault();

                var result = await this.sut.Handle(
                    new OpenTicketCommand
                {
                    ContentId = "1",
                    Category = "Some",
                    Content = topic.Content,
                    ContentType = contentType,
                    UserId = "1",
                    AdditionalInformation = "Somthing",
                }, CancellationToken.None);

                context.Tickets.Count().ShouldBe(1);

                var ticket = this.context.Tickets.FirstOrDefault();

                ticket.SentOn.ShouldNotBeNull();
                ticket.TopicId.ShouldBe(topic.Id);
                ticket.ReportedUserId.ShouldBe(topic.UserId);
                ticket.Type.ShouldBe("Topic");
                ticket.Content.ShouldBe(topic.Content);
                ticket.Category.ShouldBe("Some");
                ticket.AdditionalInformation.ShouldBe("Somthing");
                ticket.UserId.ShouldBe("1");

                result.ShouldBe(string.Format(GConst.OpenTicketRedirect));

            }
            else if (contentType == "Comment")
            {
                var comment = this.context.Comments.FirstOrDefault();

                var result = await this.sut.Handle(
                    new OpenTicketCommand
                {
                    ContentId = "1",
                    Category = "Some",
                    Content = comment.Content,
                    ContentType = contentType,
                    UserId = "1",
                    AdditionalInformation = "Somthing",
                }, CancellationToken.None);

                context.Tickets.Count().ShouldBe(2);

                var ticket = this.context.Tickets.FirstOrDefault(t => t.CommentId != null);

                ticket.SentOn.ShouldNotBeNull();
                ticket.CommentId.ShouldBe("1");
                ticket.ReportedUserId.ShouldBe(comment.UserId);
                ticket.Type.ShouldBe("Comment");
                ticket.Content.ShouldBe(comment.Content);
                ticket.Category.ShouldBe("Some");
                ticket.AdditionalInformation.ShouldBe("Somthing");
                ticket.UserId.ShouldBe("1");

                result.ShouldBe(string.Format(GConst.OpenTicketRedirect));
            }
            else
            {
                var message = this.context.Messages.FirstOrDefault();

                var result = await this.sut.Handle(
                    new OpenTicketCommand
                {
                    ContentId = "1",
                    Category = "Some",
                    Content = message.Content,
                    ContentType = contentType,
                    UserId = "1",
                    AdditionalInformation = "Somthing",
                }, CancellationToken.None);

                context.Tickets.Count().ShouldBe(3);

                var ticket = this.context.Tickets.FirstOrDefault(t => t.MessageId != null);

                ticket.SentOn.ShouldNotBeNull();
                ticket.MessageId.ShouldBe(message.Id);
                ticket.ReportedUserId.ShouldBe(ticket.UserId);
                ticket.Type.ShouldBe("Message");
                ticket.Content.ShouldBe(ticket.Content);
                ticket.Category.ShouldBe("Some");
                ticket.AdditionalInformation.ShouldBe("Somthing");
                ticket.UserId.ShouldBe("1");

                result.ShouldBe(string.Format(GConst.OpenTicketRedirect));
            }
        }
    }
}
