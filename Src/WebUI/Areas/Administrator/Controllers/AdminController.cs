namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.Users.Queries;
    using Application.CQ.Common.Commands;
    using Application.GameCQ.Image.Queries;
    using Application.GameCQ.Monster.Queries;
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
            return this.View(await this.Mediator.Send(new GetMonstersImagesQuery { }));
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> ClassCatalog()
        {
            return this.View(await this.Mediator.Send(new GetFightingClassImagesQuery { }));
        }

        [HttpGet]
        public ActionResult GameContent()
        {
            return this.View();
        }

        [HttpPut]
        public async Task<ActionResult> Logout()
        {
            return this.Redirect(await this.Mediator.Send(new CustomLogoutCommand { }));
        }

        [HttpGet]
        public async Task<ActionResult> Feedback()
        {
            return this.View();
        }
    }
}
