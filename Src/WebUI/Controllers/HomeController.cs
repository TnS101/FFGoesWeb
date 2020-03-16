namespace FinalFantasyTryoutGoesWeb.WebUI.Controllers
{
    using global:: Application.GameCQ.Image.Queries;
    using global::Application.GameCQ.Monster.Queries;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class HomeController : BaseController
    {
        [HttpGet("/")]
        [Route("/")]
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
        public async Task<ActionResult> MonsterCatalog()
        {
            return View(await this.Mediator.Send(new GetMonstersImagesQuery { }));
        }

        [HttpGet("Home/ClassCatalog")]
        [Route("Home/ClassCatalog")]
        public async Task<ActionResult> ClassCatalog() 
        {
            return View(await this.Mediator.Send(new GetFightingClassImagesQuery {  }));
        }
    }
}
