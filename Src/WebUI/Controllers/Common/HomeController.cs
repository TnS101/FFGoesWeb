namespace WebUI.Controllers.Common
{
    using System.Threading.Tasks;
    using global::Application.GameCQ.Image.Queries;
    using global::Application.GameCQ.Monster.Queries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [AllowAnonymous]
    public class HomeController : BaseController
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return this.View(this.User);
        }

        [HttpGet]
        public IActionResult About()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<ActionResult> MonsterCatalog()
        {
            return this.View(await this.Mediator.Send(new GetMonstersImagesQuery { }));
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> ClassCatalog()
        {
            return this.View(await this.Mediator.Send(new GetFightingClassImagesQuery { }));
        }
    }
}
