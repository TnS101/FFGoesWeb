﻿namespace WebUI.Controllers.Common
{
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GConst.UserRole)]
    public class GuideController : BaseController
    {
        [HttpGet]
        public IActionResult About()
        {
            return this.View();
        }
    }
}
