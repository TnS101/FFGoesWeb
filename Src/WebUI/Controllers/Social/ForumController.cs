namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Social.Likes.Command.Create;
    using Application.CQ.Social.Topics.Queries.GetAllTopicsQuery;
    using Application.CQ.Social.Topics.Queries.GetCurrentTopicQuery;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class ForumController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Home([FromQuery]string[] check)
        {
            return this.View(await this.Mediator.Send(new GetAllTopicsQuery { Filter = check }));
        }

        [HttpGet("Forum/CurrentTopic/id")]
        public async Task<ActionResult> CurrentTopic([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentTopicQuery { TopicId = id }));
        }
    }
}
