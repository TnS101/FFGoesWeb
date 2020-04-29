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
        public async Task<IActionResult> Panel()
        {
            return this.View(await this.Mediator.Send(new UserPanelQuery { UserId = this.UserManager.GetUserId(this.User) }));
        }

        [HttpGet]
        public async Task<IActionResult> Status()
        {
            return this.PartialView("_Statuses", await this.Mediator.Send(new GetAllStatusesQuery { }));
        }

        [HttpGet("/UpdateStatus/id")]
        public async Task<IActionResult> UpdateStatus([FromQuery]int id)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateStatusCommand { StatusId = id, User = this.User }));
        }

        [HttpGet]
        public async Task<IActionResult> Topics()
        {
            return this.View(await this.Mediator.Send(new GetAllTopicsQuery { User = this.User }));
        }

        [HttpGet]
        public async Task<IActionResult> MasteryPoints()
        {
            return this.View(await this.Mediator.Send(new GetHeroListQuery { User = this.User }));
        }

        [HttpGet]
        public async Task<IActionResult> ForumPoints()
        {
            return this.View(await this.Mediator.Send(new GetCurrentUserQuery { User = this.User }));
        }

        [HttpPost]
        public async Task<IActionResult> SendFeedback([Bind("Content,Rate")] SendFeedbackCommand feedback)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect(GConst.FeedbackErrorRedirect);
            }

            return this.View(await this.Mediator.Send(new SendFeedbackCommand { Content = feedback.Content, Rate = feedback.Rate, Sender = this.User }));
        }

        [HttpGet]
        public async Task<IActionResult> Feedbacks()
        {
            return this.View(await this.Mediator.Send(new GetPersonalFeedbacksQuery { User = this.User }));
        }

        [HttpGet("/Profile/User/id")]
        public async Task<IActionResult> CurrentUser([FromQuery] string id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentUserQuery { UserId = id }));
        }
    }
}
