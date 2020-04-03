namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Forum.Topic.Queries.GetAllTopicsQuery;
    using Application.CQ.Forum.Topic.Queries.GetCurrentTopicQuery;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    // [Authorize]
    public class ForumController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Home()
        {
            return this.View(await this.Mediator.Send(new GetAllTopicsQuery { }));
        }

        [HttpGet("Forum/CurrentTopic/id")]
        public async Task<ActionResult> CurrentTopic([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentTopicQuery { TopicId = id }));
        }
    }
}
