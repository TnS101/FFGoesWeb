namespace WebUI.Controllers.Game
{
    using System.Threading.Tasks;
    using Application.GameCQ.Heroes.Queries.GetUnitListQuery;
    using Application.GameCQ.Treasures.Commands.Update;
    using Application.GameCQ.World.Commands.Update;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    // [Authorize(Roles = "User")]
    public class WorldController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Home()
        {
            return this.View(await this.Mediator.Send(new GetUnitListQuery { User = this.User }));
        }

        [HttpGet]
        public async Task<ActionResult> Explore()
        {
            return this.Redirect(await this.Mediator.Send(new ExploreCommand { User = this.User }));
        }

        [HttpGet]
        public async Task<IActionResult> TreasureEncounter()
        {
            return this.View(@"\TreasureEncounter", await this.Mediator.Send(new LootTreasureCommand { User = this.User }));
        }
    }
}
