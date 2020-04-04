namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Social.Message.Commands.Create;
    using Application.CQ.Social.Message.Queries;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class MessageController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> All([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send(new GetPersonalMessagesQuery { Reciever = this.User, SenderId = id }));
        }

        [HttpPost]
        public async Task<ActionResult> Send([FromQuery]string recieverName, [FromBody]string content)
        {
            return this.Redirect(await this.Mediator.Send(new SendMessageCommand { Sender = this.User, RecieverName = recieverName, Content = content }));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteMessageCommand { MessageId = id }));
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromQuery]string id, [FromBody]string content)
        {
            return this.Redirect(await this.Mediator.Send(new EditMessageCommand { MessageId = id, Content = content }));
        }
    }
}
