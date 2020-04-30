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
        public async Task<IActionResult> All([FromForm]string check)
        {
            return this.View(await this.Mediator.Send(new GetPersonalNotificationsQuery { UserId = this.UserManager.GetUserId(this.User), Filter = check }));
        }
    }
}
