namespace WebUI.Areas.Administrator.Controllers
{
    using Application.CQ.Admin.Users.Queries;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebUI.Controllers;

    [Authorize(Roles = GConst.AdminRole)]
    [Area(GConst.AdminArea)]
    public class AdminController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Dashboard([FromForm]string role)
        {
            return View(await this.Mediator.Send(new GetOnlineUsersQuery { Role = role }));
        }
    }
}
