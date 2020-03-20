namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using global::Application.GameCQ.Treasure.Commands.Update;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Authorize(Roles = "Administrator,Player")]
    public class WorldController : BaseController
    {
        private readonly Random rng;
        public WorldController()
        {
            this.rng = new Random();
        }

        [HttpGet("/World")]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet("/Explore")]
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

        [HttpGet("/TreasureLoot")]
        public async Task<IActionResult> TreasureEncounter()
        {
            return Ok(await this.Mediator.Send(new LootTreasureCommand { User = this.User }));
        }
    }
}
