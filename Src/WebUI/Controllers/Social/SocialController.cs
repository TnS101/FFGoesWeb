namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class SocialController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Home()
        {
            return this.View(await this.UserManager.GetUserAsync(this.User));
        }
    }
}
