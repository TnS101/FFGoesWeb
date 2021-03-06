﻿namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.Moderation.Feedback.Commands.Delete.FeedbackTaskDoneCommand;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery.ToDoList;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.AdminRole)]
    [Area(GConst.AdminArea)]
    public class ToDoController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return this.View(await this.Mediator.Send(new ToDoList { }));
        }

        [HttpPost]
        public async Task<IActionResult> FinishTask([FromForm]int id)
        {
            return this.Redirect(await this.Mediator.Send(new FeedbackTaskDoneCommand { FeedbackId = id }));
        }
    }
}
