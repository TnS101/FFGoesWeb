namespace WebUI.Controllers
{
    using Application.CQ.Forum.Topic.Queries.GetAllTopicsQuery;
    using Application.CQ.Forum.Topic.Queries.GetCurrentTopicQuery;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    public class ForumController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Home() 
        {
            return View(await this.Mediator.Send(new GetAllTopicsQuery { }));
        }

        [HttpGet]
        public async Task<ActionResult> CurrentTopic([FromQuery]string topicId) 
        {
            return View(await this.Mediator.Send(new GetCurrentTopicQuery { TopicId = topicId }));
        }
    }
}
