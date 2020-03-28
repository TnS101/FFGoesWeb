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
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    // [Authorize(Roles = "Administrator,User")]
    public class UnitController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return this.View(await this.Mediator.Send(new GetAllFightingClassesQuery{ }));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm]string fightingClass, [FromForm]string race, [FromForm]string name)
        {
            return this.Redirect(await this.Mediator.Send(new CreateHeroCommand { ClassType = fightingClass, Race = race, Name = name, User = this.User }));
        }

        [HttpPost]
        public async Task<ActionResult> Delete([FromForm]int heroId)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteHeroCommand { HeroId = heroId }));
        }

        [HttpGet]
        public async Task<ActionResult> Info()
        {
            return this.View(await this.Mediator.Send(new GetFullUnitQuery { User = this.User }));
        }

        [HttpPost]
        public async Task<ActionResult> Equip([FromForm]int id, [FromForm]string command)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateEquipmentCommand { ItemId = id, Command = command, User = this.User }));
        }

        [HttpPost]
        public async Task<ActionResult> UnEquip([FromForm] int id, [FromForm]string command)
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
            await this.Mediator.Send(new HeroLevelUpCommand());

            return this.View();
        }

        [HttpGet]
        public async Task<ActionResult> Select([FromQuery]int id)
        {
            return this.Redirect(await this.Mediator.Send(new SelectHeroCommand { Id = id, User = this.User }));
        }
    }
}
