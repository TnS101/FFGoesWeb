namespace WebUI.Areas.Moderator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Moderator.Queries.GetAllTicketsQuery;
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Area(GConst.ModeratorArea)]
    public class ModController : BaseController
    {
        [HttpGet("/Moderator/Index")]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<ActionResult> Tickets()
        {
            return this.View(await this.Mediator.Send(new GetAllTicketsQuery { }));
        }
    }
}
