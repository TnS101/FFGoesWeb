namespace WebUI.Controllers.Common
{
    using System.Threading.Tasks;
    using Application.CQ.User.Queries.Panel;
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
    }
}
