using Application.CQ.Moderator.Commands.Update;
using Application.Tests.Infrastructure;
using Common;
using Domain.Entities.Common;
using Domain.Entities.Moderation;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CQ.Moderator.Commands
{
    public class CloseTicketCommandHandlerTests : CommandTestBase
    {
        private readonly CloseTicketCommandHandler sut;

        public CloseTicketCommandHandlerTests()
        {
            this.sut = new CloseTicketCommandHandler(context);
            CommandArrangeHelper.GetTopicId(context);
            QueryArrangeHelper.AddComments(context);
            CommandArrangeHelper.GetMessageId(context);
            CommandArrangeHelper.GetTicketId(context);
            QueryArrangeHelper.AddUsers(context);
            QueryArrangeHelper.AddLikes(context);
        }

        [Fact]
        public async Task ShouldCloseTicketProperly()
        {
            var reporter = this.context.AppUsers.Find("1");
            var reported = this.context.AppUsers.Find("2");

            var ticket = this.context.Tickets.FirstOrDefault();

            this.UpdateTicket(ticket, "Comment");
            await this.Result(reporter, reported, ticket);

            this.UpdateTicket(ticket, "Message");
            await this.Result(reporter, reported, ticket);

            reported.Warnings = 2;
            context.Update(reported);
            context.SaveChanges();

            await this.Result(reporter, reported, ticket);

            reported.Warnings = 3;
            context.Update(reported);
            context.SaveChanges();

            await this.Result(reporter, reported, ticket);
        }

        private void UpdateTicket(Ticket ticket, string type)
        {
            if (type == "Comment")
            {
                ticket.Type = "Comment";
            }
            else
            {
                ticket.Type = "Message";
            }

            context.Tickets.Update(ticket);
            context.SaveChanges();
        }

        private async Task Result(AppUser reporter, AppUser reported, Ticket ticket)
        {
            var result = await this.sut.Handle(new CloseTicketCommand { Stars = 1, TicketId = 1 }, CancellationToken.None);

            result.ShouldBe(GConst.TicketCommandRedirect);

            reporter.Stars.ShouldBe(1);
            reporter.Stars = 0;
            context.AppUsers.Update(reporter);
            context.SaveChanges();

            if (reported.Warnings > 2 || reported.Warnings > 3)
            {
                context.Notifications.Count().ShouldBe(4);
                context.Notifications.RemoveRange(context.Notifications);
                context.SaveChanges();
            }

            if (reported.Warnings < 1)
            {
                context.Notifications.Count().ShouldBe(1);
                context.Notifications.RemoveRange(context.Notifications);
                context.SaveChanges();
            }

            if (ticket.Type == "Topic")
            {
                var topic = this.context.Topics.FirstOrDefault();

                topic.IsRemoved.ShouldBeTrue();
                topic.Content.ShouldBe(string.Format(GConst.RemovedContentMessage, "topic", ticket.Category));
                context.Comments.Count().ShouldBe(0);
                context.Likes.Count().ShouldBe(0);
            }
            else if (ticket.Type == "Comment")
            {
                var comment = this.context.Comments.Find("1");
                comment.IsRemoved.ShouldBeTrue();
                comment.Content.ShouldBe(string.Format(GConst.RemovedContentMessage, "comment", ticket.Category));
                context.Likes.Count().ShouldBe(0);
            }
            else
            {
                var message = this.context.Messages.FirstOrDefault();
                message.IsRemoved.ShouldBeTrue();
                message.Content.ShouldBe(string.Format(GConst.RemovedContentMessage, "message", ticket.Category));
            }
        }
    }
}
