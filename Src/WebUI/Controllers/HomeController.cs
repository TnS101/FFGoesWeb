namespace FinalFantasyTryoutGoesWeb.WebUI.Controllers
{
    using FinalFantasyTryoutGoesWeb.Persistence;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class HomeController : BaseController
    {
        private readonly FFDbContext context;

        public HomeController(FFDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Home/About")]
        [Route("Home/About")]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet("Home/MonsterCatalaog")]
        [Route("Home/MonsterCatalog")]
        public IActionResult MonsterCatalog()
        {
            return View(context.Images.Where(i => i.IconURL == null && i.Description != null).ToList());
        }
    }
}
