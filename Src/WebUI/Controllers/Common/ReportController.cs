namespace WebUI.Controllers.Common
{
    using System.Threading.Tasks;
    using Application.CQ.Forum.Topic.Queries.GetCurrentTopicQuery;
    using Application.CQ.Social.Comments.Queries.GetCurrentCommentQuery;
    using Application.CQ.Users.Tickets.Command.Comments;
    using Application.CQ.Users.Tickets.Command.Messages;
    using Application.CQ.Users.Tickets.Command.Topics;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GConst.UserRole)]
    public class ReportController : BaseController
    {
        [HttpGet("Report/ReportTopic/id")]
        public async Task<ActionResult> ReportTopic([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentTopicQuery { TopicId = id }));
        }

        [HttpPost]
        public async Task<ActionResult> ReportTopic([FromForm]string topicId, [FromForm]string category, [FromForm]string additionalInformation)
        {
            return this.Redirect(await this.Mediator.Send(new OpenTopicTicketCommand
            {
                TopicId = topicId, Category = category,
                AdditionalInformation = additionalInformation, Sender = this.User,
            }));
        }

        [HttpGet]
        public async Task<ActionResult> ReportComment([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentCommentQuery { CommentId = id }));
        }

        [HttpPost]
        public async Task<ActionResult> ReportComment([FromForm]string commentId, [FromForm]string category, [FromForm]string additionalInformation)
        {
            return this.Redirect(await this.Mediator.Send(new OpenCommentTicketCommand
            {
                CommentId = commentId,
                Category = category,
                AdditionalInformation = additionalInformation,
                Sender = this.User,
            }));
        }

        [HttpGet]
        public ActionResult ReportMessage()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> ReportMessage([FromForm]string messageId, [FromForm]string category, [FromForm]string additionalInformation)
        {
            return this.Redirect(await this.Mediator.Send(new OpenMessageTicketCommand
            {
                MessageId = messageId,
                Category = category,
                AdditionalInformation = additionalInformation,
                Sender = this.User,
            }));
        }
    }
}
