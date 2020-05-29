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
        public async Task<IActionResult> All()
        {
            return this.View(await this.Mediator.Send(new GetHeroListQuery { UserId = this.UserManager.GetUserId(this.User) }));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View(await this.Mediator.Send(new GetAllFightingClassesQuery { }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Race,ClassType")] CreateHeroCommand hero)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect(GConst.HeroCreationErrorRedirect);
            }

            return this.Redirect(await this.Mediator.Send(new CreateHeroCommand { ClassType = hero.ClassType, Race = hero.Race, Name = hero.Name, UserId = this.UserManager.GetUserId(this.User) }));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteHeroCommand { HeroId = id }));
        }

        [HttpGet("/Hero/Info/id")]
        public async Task<IActionResult> Info([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send(new GetFullUnitQuery { HeroId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Equip([FromForm]string id, [FromForm]string command, [FromForm]string heroId, [FromForm]string slot)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateEquipmentCommand { ItemId = id, Command = command, HeroId = heroId, Slot = slot }));
        }

        [HttpGet("/Hero/Equipment/id&slot")]
        public async Task<IActionResult> Equipment([FromQuery]string id, [FromQuery]string slot)
        {
            return this.View(await this.Mediator.Send(new GetEquipmentQuery { HeroId = id, Slot = slot }));
        }

        [HttpGet("/Hero/Inventory/id&slot")]
        public async Task<IActionResult> Inventory([FromQuery]string id, [FromQuery]string slot)
        {
            return this.View(await this.Mediator.Send(new GetPersonalItemsQuery { HeroId = id, Slot = slot }));
        }

        [HttpPost]
        public async Task<IActionResult> DiscardItem([FromForm]long id, [FromForm]int count, [FromForm]string slot, [FromForm]long heroId)
        {
            return this.Redirect(await this.Mediator.Send(new DiscardItemCommand { ItemId = id, Count = count, Slot = slot, HeroId = heroId }));
        }

        [HttpGet]
        public async Task<IActionResult> LevelUp()
        {
            return this.View(await this.Mediator.Send(new HeroLevelUpCommand()));
        }

        [HttpPost]
        public async Task<IActionResult> Select(string id)
        {
            return this.Redirect(await this.Mediator.Send(new SelectHeroCommand { UnitId = id, UserId = this.UserManager.GetUserId(this.User) }));
        }
    }
}
