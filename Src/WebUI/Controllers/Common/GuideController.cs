namespace WebUI.Controllers.Common
{
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(GConst.UserRole)]
    public class GuideController : BaseController
    {
        [HttpGet]
        public ActionResult About()
        {
            return this.View();
        }
    }
}
