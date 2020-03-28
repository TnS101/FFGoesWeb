namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.Users.Queries;
    using Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery;
    using Application.CQ.Common.Commands;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    // [Authorize(Roles = GConst.AdminRole)]
    [Area(GConst.AdminArea)]
    public class AdminController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Dashboard([FromForm]string role)
        {
            return this.View(await this.Mediator.Send(new GetOnlineUsersQuery { Role = role }));
        }

        public ActionResult Index()
        {
            return this.View(this.User);
        }

        [HttpGet]
        public IActionResult About()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<ActionResult> MonsterCatalog()
        {
            return this.View();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> ClassCatalog()
        {
            return this.View();
        }

        [HttpPut]
        public async Task<ActionResult> Logout()
        {
            return this.Redirect(await this.Mediator.Send(new CustomLogoutCommand { }));
        }
    }
}
