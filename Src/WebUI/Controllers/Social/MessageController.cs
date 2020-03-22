namespace WebUI.Controllers.Social
{
    using Application.CQ.Forum.Message.Commands.Create;
    using Application.CQ.Forum.Message.Commands.Delete;
    using Application.CQ.Forum.Message.Commands.Update;
    using Application.CQ.Forum.Message.Queries;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebUI.Controllers.Common;

    public class MessageController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> All([FromQuery]string senderName)
        {
            return View(await this.Mediator.Send(new GetPersonalMessagesQuery { Reciever = this.User, SenderName = senderName }));
        }

        [HttpPost]
        public async Task<ActionResult> Send([FromQuery]string recieverName, [FromBody]string content)
        {
            return Redirect(await this.Mediator.Send(new SendMessageCommand { Sender = this.User, RecieverName = recieverName, Content = content }));
        }

        [HttpPost]
        public async Task<ActionResult> Delete([FromQuery]string messageId) 
        {
            return Redirect(await this.Mediator.Send(new DeleteMessageCommand { MessageId = messageId }));
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromQuery]string messageId, [FromBody]string content) 
        {
            return Redirect(await this.Mediator.Send(new EditMessageCommand { MessageId = messageId, Content = content }));
        }
    }
}
