namespace WebUI.Controllers.Common
{
    using System.Threading.Tasks;
    using Application.CQ.Social.Topics.Queries.GetAllTopicsQuery;
    using Application.CQ.Users.Feedbacks.Command;
    using Application.CQ.Users.Feedbacks.Queries;
    using Application.CQ.Users.Queries.GetCurrentUser;
    using Application.CQ.Users.Queries.Panel;
    using Application.CQ.Users.Statuses.Commands.Update;
    using Application.CQ.Users.Statuses.Queries;
    using Application.GameCQ.Heroes.Queries.GetUnitListQuery;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GConst.UserRole)]
    public class ProfileController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Panel()
        {
            return this.View(await this.Mediator.Send(new UserPanelQuery { User = this.User }));
        }

        [HttpGet]
        public async Task<ActionResult> Status()
        {
            return this.PartialView("_Statuses", await this.Mediator.Send(new GetAllStatusesQuery { }));
        }

        [HttpGet]
        public async Task<ActionResult> Statuses()
        {
            return this.Json(await this.Mediator.Send(new GetAllStatusesQuery { }));
        }

        [HttpGet("/UpdateStatus/id")]
        public async Task<ActionResult> UpdateStatus([FromQuery]int id)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateStatusCommand { StatusId = id, User = this.User }));
        }

        [HttpGet]
        public async Task<ActionResult> Topics()
        {
            return this.View(await this.Mediator.Send(new GetAllTopicsQuery { User = this.User }));
        }

        [HttpGet]
        public async Task<ActionResult> MasteryPoints()
        {
            return this.View(await this.Mediator.Send(new GetHeroListQuery { User = this.User }));
        }

        [HttpGet]
        public async Task<ActionResult> ForumPoints()
        {
            return this.View(await this.Mediator.Send(new GetCurrentUserQuery { User = this.User }));
        }

        [HttpPost]
        public async Task<ActionResult> LeaveFeedback([FromForm]string feedback, [FromForm]int rate)
        {
            return this.View(await this.Mediator.Send(new SendFeedbackCommand { Content = feedback, Sender = this.User, Rate = rate }));
        }

        [HttpGet]
        public async Task<ActionResult> Feedbacks()
        {
            return this.View(await this.Mediator.Send(new GetPersonalFeedbacksQuery { User = this.User }));
        }

        [HttpGet("/Profile/User/id")]
        public async Task<ActionResult> CurrentUser([FromQuery] string id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentUserQuery { UserId = id }));
        }
    }
}
