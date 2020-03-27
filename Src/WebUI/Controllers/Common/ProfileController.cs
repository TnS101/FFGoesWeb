namespace WebUI.Controllers.Common
{
    using System;
    using System.Threading.Tasks;
    using Application.CQ.User.Queries.Panel;
    using Application.CQ.User.Status.Commands.Update;
    using Application.CQ.User.Status.Queries;
    using Application.GameCQ.Unit.Queries.GetUnitListQuery;
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
        public async Task<ActionResult> UpdateStatus([FromForm]string statusName)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateStatusCommand { StatusName = statusName, User = this.User }));
        }
    }
}
