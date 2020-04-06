namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Social.Notifications.Queries.GetPersonalNotificationsQuery;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    public class NotificationController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> All([FromForm]string check)
        {
            return this.View(await this.Mediator.Send(new GetPersonalNotificationsQuery { User = this.User, Filter = check }));
        }
    }
}
