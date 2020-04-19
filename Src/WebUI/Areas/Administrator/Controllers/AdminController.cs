namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.AdminRole)]
    [Area(GConst.AdminArea)]
    public class AdminController : BaseController
    {
        [HttpGet("Administrator/Admin/")]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await this.SignInManager.SignOutAsync();

            return this.View();
        }
    }
}
