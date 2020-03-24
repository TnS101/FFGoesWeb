namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

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
            return this.View();
        }
    }
}
