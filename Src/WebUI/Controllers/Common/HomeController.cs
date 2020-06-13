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
        public IActionResult Index()
        {
            return this.View(this.User);
        }

        [Authorize(Roles = GConst.UserRole)]
        [HttpGet("/MonsterCatalog")]
        public async Task<IActionResult> MonsterCatalog()
        {
            return this.View(await this.Mediator.Send(new GetAllMonstersQuery { }));
        }

        [Authorize(Roles = GConst.UserRole)]
        [HttpGet("/MonsterInfo/id")]
        public async Task<IActionResult> MonsterInfo([FromQuery]int id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentMonsterQuery { MonsterId = id }));
        }

        [Authorize(Roles = GConst.UserRole)]
        [HttpGet("/PrivacyPolicy")]
        public IActionResult PrivacyPolicy()
        {
            return this.View();
        }
    }
}
