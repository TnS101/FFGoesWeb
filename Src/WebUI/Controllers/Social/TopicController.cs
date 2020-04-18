namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Social.Likes.Command.Create;
    using Application.CQ.Social.Likes.Command.Delete;
    using Application.CQ.Social.Topics.Commands.Create;
    using Application.CQ.Social.Topics.Commands.Delete;
    using Application.CQ.Social.Topics.Commands.Update;
    using Application.CQ.Social.Topics.Queries.GetCurrentTopicQuery;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class TopicController : BaseController
    {
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind("Title,Category,Content")] CreateTopicCommand topic)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(topic);
            }

            await this.Mediator.Send(new CreateTopicCommand { Title = topic.Title, Category = topic.Category, Content = topic.Content, User = this.User });

            return this.Redirect(GConst.TopicCommandRedirect);
        }

        [HttpGet("/Topic/Delete/id")]
        public async Task<ActionResult> Delete([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteTopicCommand { TopicId = id }));
        }

        [HttpGet("/Topic/Edit/id")]
        public async Task<ActionResult> Edit([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentTopicQuery { TopicId = id }));
        }

        [HttpPost]
        public async Task<ActionResult> Edit([Bind("Title,Category,Content")] TopicFullViewModel topic, [FromForm]string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(topic);
            }

            return this.Redirect(await this.Mediator.Send(new EditTopicCommand { Id = id, Title = topic.Title, Category = topic.Category, Content = topic.Content }));
        }

        [HttpGet("/Topic/Like/id")]
        public async Task<ActionResult> Like([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new LeaveLikeCommand { TopicId = id, User = this.User }));
        }

        [HttpGet("/Topic/Dislike/id")]
        public async Task<ActionResult> Dislike([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DislikeCommand { TopicId = id, User = this.User }));
        }

        [HttpGet]
        public ActionResult InModeration()
        {
            return this.View();
        }
    }
}
