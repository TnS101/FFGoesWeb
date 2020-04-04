namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Forum.Topic.Commands.Create;
    using Application.CQ.Forum.Topic.Commands.Delete;
    using Application.CQ.Forum.Topic.Commands.Update;
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
        public async Task<ActionResult> Create([FromForm]string title, [FromForm]string category, [FromForm]string content)
        {
            return this.View(await this.Mediator.Send(new CreateTopicCommand { Title = title, Category = category, Content = content, User = this.User }));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteTopicCommand { TopicId = id }));
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return this.View();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromQuery]string id, [FromForm]string title, [FromForm]string category,
            [FromForm]string content)
        {
            return this.Redirect(await this.Mediator.Send(new EditTopicCommand { TopicId = id, Title = title, Category = category, Content = content }));
        }
    }
}
