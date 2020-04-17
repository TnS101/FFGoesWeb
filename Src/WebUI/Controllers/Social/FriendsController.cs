namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Social.FriendRequests.Commands.Create;
    using Application.CQ.Social.FriendRequests.Commands.Delete;
    using Application.CQ.Social.FriendRequests.Commands.Update;
    using Application.CQ.Social.FriendRequests.Queries;
    using Application.CQ.Social.Friends.Commands.Delete;
    using Application.CQ.Social.Friends.Queries.GetAllFriendsQuery;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class FriendsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Requests()
        {
            return this.View(await this.Mediator.Send(new GetPersonalFriendRequestsQuery { Reciever = this.User }));
        }

        [HttpPost]
        public async Task<ActionResult> SendRequest([FromForm]string id)
        {
            return this.Redirect(await this.Mediator.Send(new SendFriendRequestCommand { Sender = this.User, RecieverId = id }));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRequest([FromForm]int id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteFriendRequestCommand { RequestId = id }));
        }

        [HttpPost]
        public async Task<ActionResult> AcceptRequest([FromQuery]int id)
        {
            return this.Redirect(await this.Mediator.Send(new AcceptFriendRequestCommand { Reciever = this.User, RequestId = id }));
        }

        [HttpGet]
        public async Task<ActionResult> All()
        {
            return this.View(await this.Mediator.Send(new GetAllFriendsQuery { User = this.User }));
        }

        [HttpDelete]
        public async Task<ActionResult> Remove([FromForm]string friendId)
        {
            return this.Redirect(await this.Mediator.Send(new RemoveFriendCommand { User = this.User, FriendId = friendId }));
        }
    }
}
