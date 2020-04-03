﻿namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Social.Comments.Commands.Create;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

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

        [HttpGet]
        public async Task<ActionResult> Delete([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteCommentCommand { CommentId = id }));
        }

        [HttpGet]
        public async Task<ActionResult> Edit([FromQuery]string id, [FromForm]string content)
        {
            return this.Redirect(await this.Mediator.Send(new EditCommentCommand { Content = content, CommentId = id }));
        }
    }
}
