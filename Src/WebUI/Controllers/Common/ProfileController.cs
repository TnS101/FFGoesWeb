namespace WebUI.Controllers.Common
{
    using System.Threading.Tasks;
    using Application.CQ.Users.Queries.Panel;
    using Application.CQ.Users.Statuses.Commands.Update;
    using Application.CQ.Users.Statuses.Queries;
    using Application.GameCQ.Heroes.Queries.GetUnitListQuery;
    using Microsoft.AspNetCore.Mvc;

    // [Authorize(Roles = GConst.UserRole)]
    public class ProfileController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Units()
        {
            return this.View(await this.Mediator.Send(new GetUnitListQuery { User = this.User }));
        }

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

        [HttpPost]
        public async Task<ActionResult> UpdateStatus([FromForm]int id)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateStatusCommand { StatusId = id, User = this.User }));
        }
    }
}
