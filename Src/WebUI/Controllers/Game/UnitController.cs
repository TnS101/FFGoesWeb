namespace WebUI.Controllers.Game
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
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class UnitController : BaseController
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
        public async Task<ActionResult> Create([FromForm]string fightingClass, [FromForm]string race, [FromForm]string name)
        {
            return this.Redirect(await this.Mediator.Send(new CreateHeroCommand { ClassType = fightingClass, Race = race, Name = name, User = this.User }));
        }

        [HttpPost]
        public async Task<ActionResult> Delete([FromForm]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteHeroCommand { HeroId = id }));
        }

        [HttpGet("/Info/id")]
        public async Task<ActionResult> Info([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send(new GetFullUnitQuery { HeroId = id }));
        }

        [HttpPost]
        public async Task<ActionResult> Equip([FromForm]string id, [FromForm]string command)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateEquipmentCommand { ItemId = id, Command = command, User = this.User }));
        }

        [HttpPost]
        public async Task<ActionResult> UnEquip([FromForm] string id, [FromForm]string command)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateEquipmentCommand { ItemId = id, Command = command, User = this.User }));
        }

        [HttpGet]
        public async Task<ActionResult> Equipment([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send(new GetEquipmentQuery { HeroId = id }));
        }

        [HttpGet]
        public async Task<ActionResult> Inventory([FromQuery]string id, [FromForm]string slot)
        {
            return this.View(await this.Mediator.Send(new GetPersonalItemsQuery { HeroId = id, Slot = slot }));
        }

        [HttpGet]
        public async Task<ActionResult> LevelUp()
        {
            await this.Mediator.Send(new HeroLevelUpCommand());

            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Select(string id)
        {
            return this.Redirect(await this.Mediator.Send(new SelectHeroCommand { UnitId = id, User = this.User }));
        }
    }
}
