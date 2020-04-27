namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.GameContent.Items.Queries.GetAllItemsQuery;
    using Application.CQ.Admin.GameContent.Spells.Queries.GetAllSpellsQuery;
    using Application.GameCQ.FightingClasses.Queries.GetAllFightingClassesQuery;
    using Application.GameCQ.Monsters.Queries.GetAllMonstersQuery;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.AdminRole)]
    [Area(GConst.AdminArea)]
    public class GameContentController : BaseController
    {
        [HttpGet]
        public IActionResult Content()
        {
            return this.View();
        }

        [HttpGet("Administrator/GameContent/Items/slot")]
        public async Task<IActionResult> Items([FromQuery]string slot)
        {
            return this.View(await this.Mediator.Send(new GetAllItemsQuery { Slot = slot }));
        }

        [HttpGet]
        public async Task<IActionResult> Spells([FromQuery]string classType)
        {
            return this.View(await this.Mediator.Send(new GetAllSpellsQuery { ClassType = classType }));
        }

        [HttpGet]
        public async Task<IActionResult> Monsters()
        {
            return this.View(await this.Mediator.Send(new GetAllMonstersQuery { }));
        }

        [HttpGet]
        public async Task<IActionResult> FightingClasses()
        {
            return this.View(await this.Mediator.Send(new GetAllFightingClassesQuery { }));
        }
    }
}
