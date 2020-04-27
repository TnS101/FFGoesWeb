namespace WebUI.Areas.Moderator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Moderator.Queries.GetAllTicketsQuery;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.ModeratorRole)]
    [Area(GConst.ModeratorArea)]
    public class ModController : BaseController
    {
        [HttpGet("/Moderator/Mod/")]
        public async Task<IActionResult> Tickets()
        {
            return this.View(await this.Mediator.Send(new GetAllTicketsQuery { }));
        }
    }
}
