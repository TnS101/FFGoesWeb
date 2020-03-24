namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.Moderation.Feedback.Commands.Delete;
    using Application.CQ.Admin.Moderation.Feedback.Commands.Update;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetCurrentFeedbackQuery;
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Area(GConst.AdminArea)]
    public class FeedbackController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Feedbacks()
        {
            return this.View(await this.Mediator.Send(new GetAllFeedbacksQuery { }));
        }

        [HttpGet]
        public async Task<ActionResult> CurrentFeedback([FromQuery]string feedbackId)
        {
            return this.View(await this.Mediator.Send(new GetCurrentFeedbackQuery { FeedbackId = feedbackId }));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]string feedbackId)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteFeedbackCommand { FeedbackId = feedbackId }));
        }

        [HttpPut]
        public async Task<ActionResult> Accept([FromQuery]string feedbackId, [FromBody]int stars)
        {
            return this.Redirect(await this.Mediator.Send(new AcceptFeedbackCommand { FeedbackId = feedbackId, Stars = stars }));
        }
    }
}
