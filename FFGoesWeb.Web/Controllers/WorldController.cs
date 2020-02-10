namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using FinalFantasyTryoutGoesWeb.Data;
    using FinalFantasyTryoutGoesWeb.Data.Entities;
    using FinalFantasyTryoutGoesWeb.GameContent.Utilities.Generators;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class WorldController : Controller
    {
        private static readonly FFDbContext context = new FFDbContext();
        private readonly Unit player = context.Units.FirstOrDefault();
        private readonly Random rng = new Random();
        private readonly TreasureGenerator treasureGenerator = new TreasureGenerator();

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
        public async Task<IActionResult> TreasureEncounter(string option)
        {
            option = Request.Query["option"];
            await context.SaveChangesAsync();

            return View(treasureGenerator.Generate(player,rng,option));
        }
    }
}
