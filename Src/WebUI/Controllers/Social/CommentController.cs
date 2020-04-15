namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Social.Comments.Commands.Create;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class CommentController : BaseController
    {
        [HttpGet("Comment/Create/id")]
        public ActionResult Create([FromQuery]string id)
        {
            return this.View(@"\Create", id);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm]string topicId, [FromForm]string content)
        {
            return this.Redirect(await this.Mediator.Send(new CreateCommentCommand { TopicId = topicId, Content = content, User = this.User }));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromForm]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteCommentCommand { CommentId = id }));
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromForm]string id, [FromForm]string content)
        {
            return this.Redirect(await this.Mediator.Send(new EditCommentCommand { Content = content, CommentId = id }));
        }
    }
}
