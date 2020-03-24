namespace WebUI.Areas.Moderator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Common.Commands;
    using Application.CQ.Moderator.Queries.GetAllTicketsQuery;
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Area(GConst.ModeratorArea)]
    public class ModController : BaseController
    {
        [HttpGet("/Moderator")]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPut]
        public async Task<ActionResult> Logout()
        {
            return this.Redirect(await this.Mediator.Send(new CustomLogoutCommand { }));
        }

        [HttpGet]
        public async Task<ActionResult> Tickets()
        {
            return this.View(await this.Mediator.Send(new GetAllTicketsQuery { }));
        }
    }
}
