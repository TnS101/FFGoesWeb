namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Social.Comments.Commands.Create;
    using Application.CQ.Social.Likes.Command.Create;
    using Application.CQ.Social.Likes.Command.Delete;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class CommentController : BaseController
    {
        [HttpGet("/Comment/Create/id")]
        public IActionResult Create([FromQuery]string id)
        {
            return this.View(@"\Create", id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]string topicId, [FromForm]string content)
        {
            return this.Redirect(await this.Mediator.Send(new CreateCommentCommand { TopicId = topicId, Content = content, User = this.User }));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteCommentCommand { CommentId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm]string id, [FromForm]string content)
        {
            return this.Redirect(await this.Mediator.Send(new EditCommentCommand { Content = content, CommentId = id }));
        }

        [HttpGet("/Comment/Like/id")]
        public async Task<IActionResult> Like([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new LeaveLikeCommand { CommentId = id, User = this.User }));
        }

        [HttpGet("/Comment/Dislike/id")]
        public async Task<IActionResult> Dislike([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DislikeCommand { CommentId = id, User = this.User }));
        }
    }
}
