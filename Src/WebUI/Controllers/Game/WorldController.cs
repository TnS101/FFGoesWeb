namespace WebUI.Controllers.Game
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.GameCQ.Unit.Queries.GetUnitListQuery;
    using global::Application.GameCQ.Treasure.Commands.Update;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    //[Authorize(Roles = "User")]
    public class WorldController : BaseController
    {
        private readonly Random rng;

        public WorldController()
        {
            this.rng = new Random();
        }

        [HttpGet]
        public async Task<ActionResult> Home()
        {
            return this.View(await this.Mediator.Send(new GetUnitListQuery { User = this.User }));
        }

        [HttpGet]
        public IActionResult Explore()
        {
            int exploreNumber = this.rng.Next(0, 10);
            if (exploreNumber >= 0 && exploreNumber <= 10)
            {
                return this.View(@"\EnemyEncounter");
            }
            else
            {
                return this.View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> TreasureEncounter()
        {
            return this.View(@"\TreasureEncounter", await this.Mediator.Send(new LootTreasureCommand { User = this.User }));
        }
    }
}
