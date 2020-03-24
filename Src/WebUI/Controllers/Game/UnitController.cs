﻿namespace WebUI.Controllers.Game
{
    using System.Threading.Tasks;
    using global::Application.GameCQ.Equipment.Commands.Update;
    using global::Application.GameCQ.Equipment.Queries;
    using global::Application.GameCQ.Image.Queries;
    using global::Application.GameCQ.Unit.Commands.Create;
    using global::Application.GameCQ.Unit.Commands.Delete;
    using global::Application.GameCQ.Unit.Commands.Update;
    using global::Application.GameCQ.Unit.Queries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = "Administrator,User")]
    public class UnitController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> All() // TODO: Move to ProfileController
        {
            return this.View(await this.Mediator.Send(new GetUnitListQuery { User = this.User }));
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return this.View(await this.Mediator.Send(new GetFightingClassImagesQuery()));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromQuery]string fightingClass, [FromForm]string race, [FromForm]string name)
        {
            return this.Redirect(await this.Mediator.Send(new CreateUnitCommand { ClassType = fightingClass, Race = race, Name = name, User = this.User }));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]string unitId)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteUnitCommand { UnitId = unitId }));
        }

        [HttpGet]
        public async Task<ActionResult> Info()
        {
            return this.View(await this.Mediator.Send(new GetFullUnitQuery { User = this.User }));
        }

        [HttpPut]
        public async Task<IActionResult> Equip([FromQuery]string itemId, [FromQuery]string command)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateEquipmentCommand { ItemId = itemId, Command = command, User = this.User }));
        }

        [HttpPut]
        public async Task<IActionResult> UnEquip([FromQuery] string itemId, [FromQuery]string command)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateEquipmentCommand { ItemId = itemId, Command = command, User = this.User }));
        }

        [HttpGet]
        public async Task<IActionResult> Equipment([FromQuery]string unitId)
        {
            return this.View(await this.Mediator.Send(new GetEquipmentQuery { UnitId = unitId }));
        }

        [HttpGet]
        public async Task<IActionResult> LevelUp()
        {
            await this.Mediator.Send(new UnitLevelUpCommand());

            return this.View();
        }
    }
}