namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using FinalFantasyTryoutGoesWeb.Data;
    using FinalFantasyTryoutGoesWeb.Data.Entities;
    using FinalFantasyTryoutGoesWeb.GameContent.Utilities.LevelUtility;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class LevelController : Controller
    {
        private static readonly FFDbContext context = new FFDbContext();
        private Unit unit = context.Units.FirstOrDefault();
        private Level level = new Level();

        [HttpGet("Level/LevelUp")]
        [Route("Level/LevelUp")]
        public IActionResult LevelUp()
        {
            level.Up(unit);
            context.SaveChanges();
            return View();
        }
    }
}
