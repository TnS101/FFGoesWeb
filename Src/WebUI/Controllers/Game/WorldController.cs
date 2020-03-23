namespace WebUI.Controllers.Game
{
    using System;
    using System.Threading.Tasks;
    using global::Application.GameCQ.Treasure.Commands.Update;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = "Administrator,Player")]
    public class WorldController : BaseController
    {
        private readonly Random rng;

        public WorldController()
        {
            this.rng = new Random();
        }

        [HttpGet]
        public IActionResult Home()
        {
            return this.View();
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
