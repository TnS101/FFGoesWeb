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
        public async Task<IActionResult> Requests()
        {
            return this.View(await this.Mediator.Send(new GetPersonalFriendRequestsQuery { UserId = this.UserManager.GetUserId(this.User) }));
        }

        [HttpGet("Social/SendRequest/id")]
        public async Task<IActionResult> SendRequest([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new SendFriendRequestCommand { UserId = this.UserManager.GetUserId(this.User), RecieverId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRequest([FromForm]int requestId)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteFriendRequestCommand { RequestId = requestId }));
        }

        [HttpPost]
        public async Task<IActionResult> AcceptRequest([FromForm]int requestId)
        {
            return this.Redirect(await this.Mediator.Send(new AcceptFriendRequestCommand { UserId = this.UserManager.GetUserId(this.User), RequestId = requestId }));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return this.View(await this.Mediator.Send(new GetAllFriendsQuery { UserId = this.UserManager.GetUserId(this.User) }));
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromForm]string friendId)
        {
            return this.Redirect(await this.Mediator.Send(new RemoveFriendCommand { UserId = this.UserManager.GetUserId(this.User), FriendId = friendId }));
        }
    }
}
