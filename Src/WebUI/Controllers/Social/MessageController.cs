namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Social.Messages.Commands.Create;
    using Application.CQ.Social.Messages.Queries;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class MessageController : BaseController
    {
        [HttpGet("Messages/All/id")]
        public async Task<IActionResult> All([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send(new GetPersonalMessagesQuery { Reciever = this.User, SenderId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Send([FromQuery]string recieverName, [FromBody]string content)
        {
            return this.Redirect(await this.Mediator.Send(new SendMessageCommand { UserId = this.UserManager.GetUserId(this.User), RecieverName = recieverName, Content = content }));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteMessageCommand { MessageId = id }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromQuery]string id, [FromBody]string content)
        {
            return this.Redirect(await this.Mediator.Send(new EditMessageCommand { MessageId = id, Content = content }));
        }
    }
}
