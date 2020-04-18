namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Social.Topics.Commands.Create;
    using Application.CQ.Social.Topics.Commands.Delete;
    using Application.CQ.Social.Topics.Commands.Update;
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
        public async Task<ActionResult> Create([Bind("Title,Category,Content")] CreateTopicCommand createTopic)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createTopic);
            }

            await this.Mediator.Send(new CreateTopicCommand { Title = createTopic.Title, Category = createTopic.Category, Content = createTopic.Content, User = this.User });

            return this.Redirect(GConst.TopicCommandRedirect);
        }

        [HttpGet("/Topic/Delete/id")]
        public async Task<ActionResult> Delete([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteTopicCommand { TopicId = id }));
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromQuery]string id, [FromForm]string title, [FromForm]string category,
            [FromForm]string content)
        {
            return this.Redirect(await this.Mediator.Send(new EditTopicCommand { TopicId = id, Title = title, Category = category, Content = content }));
        }

        [HttpGet]
        public ActionResult InModeration()
        {
            return this.View();
        }
    }
}
