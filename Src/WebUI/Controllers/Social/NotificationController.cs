namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Social.Notifications.Queries.GetPersonalNotificationsQuery;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class NotificationController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> All([FromForm]string check)
        {
            return this.View(await this.Mediator.Send(new GetPersonalNotificationsQuery { User = this.User, Filter = check }));
        }
    }
}
