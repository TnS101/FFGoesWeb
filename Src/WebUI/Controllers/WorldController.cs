namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Generators;
    using FinalFantasyTryoutGoesWeb.Persistence;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class WorldController : BaseController
    {
        private readonly FFDbContext context;
        private readonly Unit player;
        private readonly Random rng;
        private readonly TreasureGenerator treasureGenerator = new TreasureGenerator();

        public WorldController(FFDbContext context)
        {
            player = context.Units.FirstOrDefault();
            this.context = context;
            rng = new Random();
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
        public async Task<IActionResult> TreasureEncounter([FromQuery]string option)
        {
            await context.SaveChangesAsync();

            return View(treasureGenerator.Generate(player,rng,option));
        }
    }
}
