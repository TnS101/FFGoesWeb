namespace WebUI.Controllers.Game
{
    using System;
    using System.Threading.Tasks;
    using Application.GameCQ.Heroes.Commands.Create;
    using Application.GameCQ.Unit.Commands.Update.SelectUnitCommand;
    using global::Application.GameCQ.Equipment.Commands.Update;
    using global::Application.GameCQ.Equipment.Queries;
    using global::Application.GameCQ.Unit.Commands.Delete;
    using global::Application.GameCQ.Unit.Commands.Update;
    using global::Application.GameCQ.Unit.Queries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    //[Authorize(Roles = "Administrator,User")]
    public class UnitController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm]string fightingClass, [FromForm]string race, [FromForm]string name)
        {
            return this.Redirect(await this.Mediator.Send(new CreateHeroCommand { ClassType = fightingClass, Race = race, Name = name, User = this.User }));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]int id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteUnitCommand { UnitId = id }));
        }

        [HttpGet]
        public async Task<ActionResult> Info()
        {
            return this.View(await this.Mediator.Send(new GetFullUnitQuery { User = this.User }));
        }

        [HttpPut]
        public async Task<ActionResult> Equip([FromQuery]int id, [FromQuery]string command)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateEquipmentCommand { ItemId = id, Command = command, User = this.User }));
        }

        [HttpPut]
        public async Task<ActionResult> UnEquip([FromQuery] int id, [FromQuery]string command)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateEquipmentCommand { ItemId = id, Command = command, User = this.User }));
        }

        [HttpGet]
        public async Task<ActionResult> Equipment([FromQuery]int id)
        {
            return this.View(await this.Mediator.Send(new GetEquipmentQuery { HeroId = id }));
        }

        [HttpGet]
        public async Task<ActionResult> LevelUp()
        {
            await this.Mediator.Send(new UnitLevelUpCommand());

            return this.View();
        }

        [HttpGet]
        public async Task<ActionResult> Select([FromQuery]string id)
        {
            return this.Redirect(await this.Mediator.Send(new SelectUnitCommand { Id = id, User = this.User }));
        }
    }
}
