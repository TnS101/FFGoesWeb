namespace WebUI.Areas.Moderator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Moderator.Commands.Delete;
    using Application.CQ.Moderator.Commands.Update;
    using Application.CQ.Moderator.Queries.GetCurrentTicketQuery;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.ModeratorRole)]
    [Area(GConst.ModeratorArea)]
    public class TicketController : BaseController
    {
        [HttpGet("/Moderator/Ticket/Current/ticketId")]
        public async Task<IActionResult> Current([FromQuery]int ticketId)
        {
            return this.View(await this.Mediator.Send(new GetCurrentTicketQuery { TicketId = ticketId }));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int ticketId)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteTicketCommand { TicketId = ticketId }));
        }

        [HttpPost]
        public async Task<IActionResult> Close([FromForm]int ticketId, [FromForm]int stars)
        {
            return this.Redirect(await this.Mediator.Send(new CloseTicketCommand { TicketId = ticketId, Stars = stars }));
        }
    }
}
