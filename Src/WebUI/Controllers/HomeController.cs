namespace FinalFantasyTryoutGoesWeb.WebUI.Controllers
{
    using global::Application.GameCQ.Monster.Queries;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        public HomeController()
        {
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
            return Ok(this.Mediator.Send(new GetMonstersQuery { }));
        }
    }
}
