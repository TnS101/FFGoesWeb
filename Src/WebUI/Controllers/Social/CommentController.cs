﻿namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Forum.Comment.Create;
    using Application.CQ.Forum.Comment.Delete;
    using Application.CQ.Forum.Comment.Update;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    public class CommentController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Create([FromQuery]string topicId, [FromForm]string content)
        {
            return this.Redirect(await this.Mediator.Send(new CreateCommentCommand { TopicId = topicId, Content = content, User = this.User }));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]string commentId, [FromQuery]string topicId)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteCommentCommand { CommentId = commentId, TopicId = topicId }));
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromQuery]string commentId, [FromQuery]string topicId, [FromForm]string content)
        {
            return this.Redirect(await this.Mediator.Send(new EditCommentCommand { Content = content, CommentId = commentId, TopicId = topicId }));
        }
    }
}