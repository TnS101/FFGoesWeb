namespace FinalFantasyTryoutGoesWeb.WebUI.Controllers
{
    using global:: Application.GameCQ.Image.Queries;
    using global::Application.GameCQ.Monster.Queries;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class HomeController : BaseController
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View(this.User);
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> MonsterCatalog()
        {
            return View(await this.Mediator.Send(new GetMonstersImagesQuery { }));
        }

        [HttpGet]
        public async Task<ActionResult> ClassCatalog() 
        {
            return View(await this.Mediator.Send(new GetFightingClassImagesQuery {  }));
        }
    }
}
