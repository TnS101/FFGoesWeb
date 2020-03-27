namespace WebUI.Areas.Moderator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Moderator.Commands.Delete;
    using Application.CQ.Moderator.Commands.Update;
    using Application.CQ.Moderator.Queries.GetCurrentTicketQuery;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    public class TicketController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> CurrentTicket([FromQuery]int ticketId)
        {
            return this.View(await this.Mediator.Send(new GetCurrentTicketQuery { TicketId = ticketId }));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]int ticketId)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteTicketCommand { TicketId = ticketId }));
        }

        [HttpPut]
        public async Task<ActionResult> Close([FromQuery]int ticketId, [FromForm]int stars)
        {
            return this.Redirect(await this.Mediator.Send(new CloseTicketCommand { TicketId = ticketId, Stars = stars }));
        }
    }
}
