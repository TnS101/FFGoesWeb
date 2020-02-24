namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.LevelUtility;
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
    using FinalFantasyTryoutGoesWeb.Persistence;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class LevelController : BaseController
    {
        private readonly FFDbContext context;
        private Unit unit;
        private Level level;

        public LevelController(FFDbContext context)
        {
            this.context = context;
            level = new Level();
            unit = context.Units.FirstOrDefault();
        }

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
