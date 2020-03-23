namespace WebUI.Areas.Moderator.Controllers
{
    using Application.CQ.Common.Commands;
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebUI.Controllers.Common;

    [Area(GConst.ModeratorArea)]
    public class ModController : BaseController
    {
        [HttpGet("/Moderator")]
        public ActionResult Index() 
        {
            return View();
        }

        [HttpPut]
        public async Task<ActionResult> Logout() 
        {
            return Redirect(await this.Mediator.Send(new CustomLogoutCommand { }));
        }

        [HttpGet]
        public async Task<ActionResult> Tickets() 
        {
            return View();
        }
    }
}
