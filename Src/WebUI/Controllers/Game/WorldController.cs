﻿namespace WebUI.Controllers.Game
{
    using System.Threading.Tasks;
    using Application.GameCQ.Heroes.Queries.GetUnitListQuery;
    using Application.GameCQ.LootBoxes.Commands.Update;
    using Application.GameCQ.World.Commands.Update;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class WorldController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            return this.View(await this.Mediator.Send(new GetHeroListQuery { UserId = this.UserManager.GetUserId(this.User) }));
        }

        [HttpGet]
        public async Task<IActionResult> Explore()
        {
            return this.Redirect(await this.Mediator.Send(new ExploreCommand { UserId = this.UserManager.GetUserId(this.User) }));
        }

        [HttpGet]
        public IActionResult EnemyEncounter()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> LootBoxEncounter()
        {
            return this.View(@"\TreasureEncounter", await this.Mediator.Send(new LootLootBoxCommand { UserId = this.UserManager.GetUserId(this.User) }));
        }
    }
}
