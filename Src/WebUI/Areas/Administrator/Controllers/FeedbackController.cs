namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery;
    using Application.CQ.Admin.Moderation.Feedbacks.Commands.Delete.DeleteFeedbackCommand;
    using Application.CQ.Admin.Moderation.Feedbacks.Commands.Update;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.AdminRole)]
    [Area(GConst.AdminArea)]
    public class FeedbackController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Feedbacks()
        {
            return this.View(await this.Mediator.Send(new GetAllFeedbacksQuery { }));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteFeedbackCommand { FeedbackId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Accept([FromForm]int id, [FromForm]int stars)
        {
            return this.Redirect(await this.Mediator.Send(new AcceptFeedbackCommand { FeedbackId = id, Stars = stars }));
        }
    }
}
