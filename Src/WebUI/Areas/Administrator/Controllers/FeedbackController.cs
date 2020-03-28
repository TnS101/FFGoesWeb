namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetCurrentFeedbackQuery;
    using Application.CQ.Admin.Moderation.Feedbacks.Commands.Delete.DeleteFeedbackCommand;
    using Application.CQ.Admin.Moderation.Feedbacks.Commands.Update;
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
        public async Task<ActionResult> CurrentFeedback([FromQuery]int id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentFeedbackQuery { FeedbackId = id }));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]int id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteFeedbackCommand { FeedbackId = id }));
        }

        [HttpPut]
        public async Task<ActionResult> Accept([FromQuery]int id, [FromBody]int stars)
        {
            return this.Redirect(await this.Mediator.Send(new AcceptFeedbackCommand { FeedbackId = id, Stars = stars }));
        }
    }
}
