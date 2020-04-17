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
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                return this.View(GConst.CreateTopicErrorRedirect, GConst.FillAllFieldsError);
            }

            if (title.Length < 5 || title.Length > 30)
            {
                return this.View(GConst.CreateTopicErrorRedirect, GConst.TitleError);
            }

            await this.Mediator.Send(new CreateTopicCommand { Title = title, Category = category, Content = content, User = this.User });

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
