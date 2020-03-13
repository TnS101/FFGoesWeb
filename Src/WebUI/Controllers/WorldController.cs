namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using global::Application.GameCQ.Treasure.Commands.Update;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class WorldController : BaseController
    {
        private readonly Random rng;
        public WorldController()
        {
            this.rng = new Random();
        }

        [HttpGet("World/Home")]
        [Route("World/Home")]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet("World/Explore")]
        [Route("World/Explore")]
        public IActionResult Explore()
        {
            int exploreNumber = rng.Next(0, 10);
            if (exploreNumber >= 0 && exploreNumber <= 10)
            {
                return View(@"\EnemyEncounter");
            }
            else
            {
                return View();
            }
        }

        [HttpGet("World/TreasureLoot")]
        [Route("World/TreasureLoot")]
        public async Task<IActionResult> TreasureEncounter()
        {
            return Ok(await this.Mediator.Send(new LootTreasureCommand { UnitId = 1 }));
        }
    }
}
