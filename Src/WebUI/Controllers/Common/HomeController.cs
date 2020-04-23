namespace WebUI.Controllers.Common
{
    using System.Threading.Tasks;
    using Application.GameCQ.Monsters.Queries.GetAllMonstersQuery;
    using Application.GameCQ.Monsters.Queries.GetCurrentMonsterQuery;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [AllowAnonymous]
    public class HomeController : BaseController
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return this.View(this.User);
        }

        [HttpGet]
        public IActionResult About()
        {
            return this.View();
        }

        [Authorize(Roles = GConst.UserRole)]
        [HttpGet]
        public async Task<ActionResult> MonsterCatalog()
        {
            return this.View(await this.Mediator.Send(new GetAllMonstersQuery { }));
        }

        [Authorize(Roles = GConst.UserRole)]
        [HttpGet("/Home/MonsterInfo/id")]
        public async Task<ActionResult> MonsterInfo([FromQuery]int id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentMonsterQuery { MonsterId = id }));
        }

        [Authorize(Roles = GConst.UserRole)]
        public ActionResult PrivacyPolicy()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Error()
        {
            return this.View();
        }
    }
}
