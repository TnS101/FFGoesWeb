namespace WebUI.Controllers.Social
{
    using Application.CQ.Forum.Comment.Create;
    using Application.CQ.Forum.Comment.Delete;
    using Application.CQ.Forum.Comment.Update;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebUI.Controllers.Common;

    public class CommentController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Create([FromQuery]string topicId,[FromForm]string content) 
        {
            return Redirect(await this.Mediator.Send(new CreateCommentCommand { TopicId = topicId, Content = content, User = this.User }));
        }

        [HttpPost]
        public async Task<ActionResult> Delete([FromQuery]string commentId, [FromQuery]string topicId) 
        {
            return Redirect(await this.Mediator.Send(new DeleteCommentCommand { CommentId = commentId, TopicId = topicId }));
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromQuery]string commentId, [FromQuery]string topicId, [FromForm]string content) 
        {
            return Redirect(await this.Mediator.Send(new EditCommentCommand { Content = content, CommentId = commentId, TopicId = topicId }));
        }
    }
}
