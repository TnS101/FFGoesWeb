namespace WebUI.Controllers.Game
{
    using System.Threading.Tasks;
    using Application.GameCQ.Consumeables.Commands.Delete;
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
        public async Task<IActionResult> Delete([FromForm]long id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteHeroCommand { HeroId = id }));
        }

        [HttpGet("/Hero/Info/id")]
        public async Task<IActionResult> Info([FromQuery]long id)
        {
            return this.View(await this.Mediator.Send(new GetFullUnitQuery { HeroId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Equip([FromForm]long id, [FromForm]string command, [FromForm]long heroId, [FromForm]string slot)
        {
            var result = await this.Mediator.Send(new UpdateEquipmentCommand { ItemId = id, Command = command, HeroId = heroId, Slot = slot });

            return this.Json(new { result });
        }

        [HttpGet("/Hero/Equipment/id&slot")]
        public async Task<IActionResult> Equipment([FromQuery]long id, [FromQuery]string slot)
        {
            return this.View(await this.Mediator.Send(new GetEquipmentQuery { HeroId = id, Slot = slot, UserId = this.UserManager.GetUserId(this.User) }));
        }

        [HttpGet("/Hero/Inventory/id&slot")]
        public async Task<IActionResult> Inventory([FromQuery]long id, [FromQuery]string slot)
        {
            if (string.IsNullOrEmpty(slot))
            {
                return this.View(await this.Mediator.Send(new GetPersonalItemsQuery { HeroId = id, Slot = slot, UserId = this.UserManager.GetUserId(this.User) }));
            }

            return this.Json(await this.Mediator.Send(new GetPersonalItemsQuery { HeroId = id, Slot = slot, UserId = this.UserManager.GetUserId(this.User) }));
        }

        [HttpPost]
        public async Task<IActionResult> DiscardItem([FromForm]long id, [FromForm]int count, [FromForm]long heroId, [FromForm]string slot)
        {
            var result = await this.Mediator.Send(new DiscardItemCommand { ItemId = id, Count = count, Slot = slot, HeroId = heroId });

            return this.Json(new { result });
        }

        [HttpPost]
        public async Task<IActionResult> Consume([FromForm]int id, [FromForm]long heroId)
        {
            await this.Mediator.Send(new ConsumeCommand { ConsumeableId = id, HeroId = heroId });

            return this.Ok();
        }

        [HttpGet]
        public async Task<IActionResult> LevelUp()
        {
            return this.View(await this.Mediator.Send(new HeroLevelUpCommand()));
        }

        [HttpPost]
        public async Task<IActionResult> Select(long id)
        {
            return this.Redirect(await this.Mediator.Send(new SelectHeroCommand { HeroId = id, UserId = this.UserManager.GetUserId(this.User) }));
        }

        [HttpGet]
        public IActionResult Killed()
        {
            return this.View();
        }
    }
}
