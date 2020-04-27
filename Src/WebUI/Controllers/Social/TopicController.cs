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
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Category,Content")] CreateTopicCommand topic)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(topic);
            }

            await this.Mediator.Send(new CreateTopicCommand { Title = topic.Title, Category = topic.Category, Content = topic.Content, User = this.User });

            return this.Redirect(GConst.TopicCommandRedirect);
        }

        [HttpGet("/Topic/Delete/id")]
        public async Task<IActionResult> Delete([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteTopicCommand { TopicId = id, User = this.User }));
        }

        [HttpGet("/Topic/Edit/id")]
        public async Task<IActionResult> Edit([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentTopicQuery { TopicId = id, User = this.User }));
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Title,Category,Content")] TopicFullViewModel topic, [FromForm]string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(topic);
            }

            return this.Redirect(await this.Mediator.Send(new EditTopicCommand { Id = id, NewTitle = topic.Title, NewCategory = topic.Category, NewContent = topic.Content }));
        }

        [HttpGet("/Topic/Like/id")]
        public async Task<IActionResult> Like([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new LeaveLikeCommand { TopicId = id, User = this.User }));
        }

        [HttpGet("/Topic/Dislike/id")]
        public async Task<IActionResult> Dislike([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DislikeCommand { TopicId = id, User = this.User }));
        }

        [HttpGet]
        public IActionResult InModeration()
        {
            return this.View();
        }
    }
}
