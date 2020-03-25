namespace WebUI.Controllers.Common
{
    using System.Threading.Tasks;
    using Application.GameCQ.Unit.Queries;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GConst.UserRole)]
    public class ProfileController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await this.SignInManager.SignOutAsync();

            return this.Redirect("/");
        }

        [HttpGet]
        public async Task<ActionResult> AllUnits() // TODO: Move to ProfileController
        {
            return this.View(await this.Mediator.Send(new GetUnitListQuery { User = this.User }));
        }
    }
}
