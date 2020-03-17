namespace WebUI.Areas.Administrator.Controllers
{
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GConst.AdminRole)]
    [Area(GConst.AdminArea)]
    public class AdminController : BaseApiController
    {
        public ActionResult Dashboard() 
        {
            return View();
        }
    }
}
