namespace WebUI.Controllers.Common
{
    using System.Threading.Tasks;
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
            return this.View();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> ClassCatalog()
        {
            return this.View();
        }
    }
}
