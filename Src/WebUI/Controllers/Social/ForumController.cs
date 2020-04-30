namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
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
        public async Task<IActionResult> Home([FromQuery]string[] check)
        {
            return this.View(await this.Mediator.Send(new GetAllTopicsQuery { Filter = check, UserId = this.UserManager.GetUserId(this.User) }));
        }

        [HttpGet("Forum/CurrentTopic/id")]
        public async Task<IActionResult> CurrentTopic([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentTopicQuery { TopicId = id, UserId = this.UserManager.GetUserId(this.User) }));
        }
    }
}
