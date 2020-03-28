namespace WebUI.Controllers.Social
{
    using Application.CQ.Social.FriendRequest.Queries;
    using Application.CQ.Social.FriendRequests.Commands.Create;
    using Application.CQ.Social.FriendRequests.Commands.Delete;
    using Application.CQ.Social.FriendRequests.Commands.Update;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebUI.Controllers.Common;

    public class FriendRequestController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> All([FromQuery]int id)
        {
            return this.View(await this.Mediator.Send(new GetPersonalFriendRequestsQuery { Reciever = this.User, RequestId = id }));
        }

        [HttpPost]
        public async Task<ActionResult> Send([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new SendFriendRequestCommand { Sender = this.User, RecieverId = id }));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]int id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteFriendRequestCommand { RequestId = id }));
        }

        [HttpPut]
        public async Task<ActionResult> Accept([FromQuery]int id)
        {
            return this.Redirect(await this.Mediator.Send(new AcceptFriendRequestCommand { Reciever = this.User, RequestId = id }));
        }
    }
}
