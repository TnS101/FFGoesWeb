﻿namespace WebUI.Controllers.Game
{
    using System.Threading.Tasks;
    using Application.GameCQ.Equipments.Commands.Update;
    using Application.GameCQ.Equipments.Queries;
    using Application.GameCQ.FightingClasses.Queries.GetAllFightingClassesQuery;
    using Application.GameCQ.Heroes.Commands.Create;
    using Application.GameCQ.Heroes.Commands.Delete;
    using Application.GameCQ.Heroes.Commands.Update.HeroLevelUpCommand;
    using Application.GameCQ.Heroes.Commands.Update.SelectHeroCommand;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetUnitListQuery;
    using Application.GameCQ.Items.Commands.Delete;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class HeroController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> All()
        {
            return this.View(await this.Mediator.Send(new GetHeroListQuery { User = this.User }));
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return this.View(await this.Mediator.Send(new GetAllFightingClassesQuery { }));
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind("Name,Race,ClassType")] CreateHeroCommand hero)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect(GConst.HeroCreationErrorRedirect);
            }

            return this.Redirect(await this.Mediator.Send(new CreateHeroCommand { ClassType = hero.ClassType, Race = hero.Race, Name = hero.Name, User = this.User }));
        }

        [HttpPost]
        public async Task<ActionResult> Delete([FromForm]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteHeroCommand { HeroId = id }));
        }

        [HttpGet("/Hero/Info/id")]
        public async Task<ActionResult> Info([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send(new GetFullUnitQuery { HeroId = id }));
        }

        [HttpPost]
        public async Task<ActionResult> Equip([FromForm]string id, [FromForm]string command, [FromForm]string heroId, [FromForm]string slot)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateEquipmentCommand { ItemId = id, Command = command, HeroId = heroId, Slot = slot }));
        }

        [HttpGet("/Hero/Equipment/id&slot")]
        public async Task<ActionResult> Equipment([FromQuery]string id, [FromQuery]string slot)
        {
            return this.View(await this.Mediator.Send(new GetEquipmentQuery { HeroId = id, Slot = slot }));
        }

        [HttpGet("/Hero/Inventory/id&slot")]
        public async Task<ActionResult> Inventory([FromQuery]string id, [FromQuery]string slot)
        {
            return this.View(await this.Mediator.Send(new GetPersonalItemsQuery { HeroId = id, Slot = slot }));
        }

        [HttpPost]
        public async Task<ActionResult> DiscardItem([FromForm]string id, [FromForm]int count, [FromForm]string slot, [FromForm]string heroId)
        {
            return this.Redirect(await this.Mediator.Send(new DiscardItemCommand { ItemId = id, Count = count, Slot = slot, HeroId = heroId }));
        }

        [HttpGet]
        public async Task<ActionResult> LevelUp()
        {
            return this.View(await this.Mediator.Send(new HeroLevelUpCommand()));
        }

        [HttpPost]
        public async Task<ActionResult> Select(string id)
        {
            return this.Redirect(await this.Mediator.Send(new SelectHeroCommand { UnitId = id, User = this.User }));
        }
    }
}
