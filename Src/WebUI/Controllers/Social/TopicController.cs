namespace WebUI.Controllers.Social
{
    using Application.CQ.Forum.Topic.Commands.Create;
    using Application.CQ.Forum.Topic.Commands.Delete;
    using Application.CQ.Forum.Topic.Commands.Update;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebUI.Controllers.Common;

    public class TopicController : BaseController
    {
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm]string title,[FromForm]string category,[FromForm]string content)
        {
            return View(await this.Mediator.Send(new CreateTopicCommand { Title = title, Category = category, Content = content , User = this.User  }));
        }

        [HttpPost]
        public async Task<ActionResult> Delete([FromQuery]string topicId) 
        {
            return Redirect(await this.Mediator.Send(new DeleteTopicCommand {  TopicId = topicId}));
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromQuery]string topicId, [FromForm]string title, [FromForm]string category
            ,[FromForm]string content)
        {
            return Redirect(await this.Mediator.Send(new EditTopicCommand { TopicId = topicId , Title = title, Category = category, Content = content }));
        }
    }
}
