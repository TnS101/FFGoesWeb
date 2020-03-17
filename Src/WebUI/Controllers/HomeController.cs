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
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("/About")]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet("/MonsterCatalog")]
        public async Task<ActionResult> MonsterCatalog()
        {
            return View(await this.Mediator.Send(new GetMonstersImagesQuery { }));
        }

        [HttpGet("/ClassCatalog")]
        [Route("/ClassCatalog")]
        public async Task<ActionResult> ClassCatalog() 
        {
            return View(await this.Mediator.Send(new GetFightingClassImagesQuery {  }));
        }
    }
}
