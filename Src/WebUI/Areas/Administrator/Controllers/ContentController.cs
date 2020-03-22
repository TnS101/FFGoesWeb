namespace WebUI.Areas.Administrator.Controllers
{
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    //[Authorize(Roles = GConst.AdminRole)]
    [Area(GConst.AdminArea)]
    public class ContentController : BaseController
    {
        [HttpGet]
        public ActionResult Moderation()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GameContent()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ForumContent()
        {
            return View();
        }
    }
}
