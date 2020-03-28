namespace WebUI.Controllers.Social
{
    using Application.CQ.Social.Message.Commands.Create;
    using Application.CQ.Social.Message.Queries;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebUI.Controllers.Common;

    public class MessageController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> All([FromQuery]string senderName)
        {
            return this.View(await this.Mediator.Send(new GetPersonalMessagesQuery { Reciever = this.User, SenderName = senderName }));
        }

        [HttpPost]
        public async Task<ActionResult> Send([FromQuery]string recieverName, [FromBody]string content)
        {
            return this.Redirect(await this.Mediator.Send(new SendMessageCommand { Sender = this.User, RecieverName = recieverName, Content = content }));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]int id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteMessageCommand { MessageId = id }));
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromQuery]int id, [FromBody]string content)
        {
            return this.Redirect(await this.Mediator.Send(new EditMessageCommand { MessageId = id, Content = content }));
        }
    }
}
