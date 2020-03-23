namespace WebUI.Controllers.Social
{
    using Application.CQ.Forum.FriendRequest.Commands.Create;
    using Application.CQ.Forum.FriendRequest.Commands.Delete;
    using Application.CQ.Forum.FriendRequest.Commands.Update;
    using Application.CQ.Forum.FriendRequest.Queries;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebUI.Controllers.Common;

    public class FriendRequestController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> All([FromQuery]string requestId) 
        {
            return View(await this.Mediator.Send(new GetPersonalFriendRequestsQuery { Reciever = this.User , RequestId = requestId }));
        } 

        [HttpPost]
        public async Task<ActionResult> Send([FromQuery]string recieverId) 
        {
            return Redirect(await this.Mediator.Send(new SendFriendRequestCommand { Sender = this.User, RecieverId = recieverId }));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]string requestId) 
        {
            return Redirect(await this.Mediator.Send(new DeleteFriendRequestCommand { RequestId = requestId }));
        }

        [HttpPut]
        public async Task<ActionResult> Accept([FromQuery]string requestId) 
        {
            return Redirect(await this.Mediator.Send(new AcceptFriendRequestCommand { Reciever = this.User, RequestId = requestId }));
        }
    }
}
