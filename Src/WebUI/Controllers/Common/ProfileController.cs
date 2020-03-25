namespace WebUI.Controllers.Common
{
    using System.Threading.Tasks;
    using Application.CQ.User.Queries.Panel;
    using Application.GameCQ.Unit.Queries;
    using Domain.Entities.Common;
    using global::Common;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GConst.UserRole)]
    public class ProfileController : BaseController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Logout()
        {
            await this.SignInManager.SignOutAsync();
            return this.Redirect("/");
        }

        [HttpGet]
        public async Task<ActionResult> AllUnits()
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
