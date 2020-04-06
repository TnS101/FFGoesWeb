namespace WebUI.Controllers.Common
{
    using Microsoft.AspNetCore.Mvc;

    public class GuideController : BaseController
    {
        [HttpGet]
        public ActionResult About()
        {
            return this.View();
        }
    }
}
