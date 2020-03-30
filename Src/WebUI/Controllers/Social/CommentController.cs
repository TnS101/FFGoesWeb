namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Social.Comments.Commands.Create;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    public class CommentController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Create([FromQuery]string id, [FromForm]string content)
        {
            return this.Redirect(await this.Mediator.Send(new CreateCommentCommand { TopicId = id, Content = content, User = this.User }));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteCommentCommand { CommentId = id }));
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromQuery]string id, [FromForm]string content)
        {
            return this.Redirect(await this.Mediator.Send(new EditCommentCommand { Content = content, CommentId = id }));
        }
    }
}
