using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Controllers.Common;

namespace WebUI.Controllers.Social
{
    public class NotificationController : BaseController
    {
        [HttpGet("Notification/All/id")]
        public async Task<ActionResult> All([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send());
        }
    }
}
