namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using FinalFantasyTryoutGoesWeb.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly FFDbContext context = new FFDbContext();

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
    }
}
