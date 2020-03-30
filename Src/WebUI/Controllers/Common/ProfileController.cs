namespace WebUI.Controllers.Common
{
    using System.Threading.Tasks;
    using Application.CQ.Users.Queries.Panel;
    using Application.CQ.Users.Statuses.Commands.Update;
    using Application.CQ.Users.Statuses.Queries;
    using Microsoft.AspNetCore.Mvc;

    // [Authorize(Roles = GConst.UserRole)]
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

        [HttpGet("/UpdateStatus/id")]
        public async Task<ActionResult> UpdateStatus([FromQuery]int id)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateStatusCommand { StatusId = id, User = this.User }));
        }
    }
}
