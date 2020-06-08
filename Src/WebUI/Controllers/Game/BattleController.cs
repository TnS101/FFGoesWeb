namespace WebUI.Controllers.Game
{
    using System.Threading.Tasks;
    using Application.GameCQ.Battles.Commands.Update;
    using Application.GameCQ.Battles.Queries.GetBattleUnitsQuery;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetPartialUnitQuery;
    using Application.GameCQ.Monsters.Commands.Create;
    using Domain.Entities.Game.Units;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class BattleController : BaseApiController
    {
        private static bool yourTurn;
        private static Monster monster;
        private static UnitFullViewModel hero;
        private static long heroId;
        private string zoneName;

        [HttpGet]
        public async Task<IActionResult> Battle([FromQuery]string zone)
        {
            this.zoneName = zone;

            var playerPVM = await this.Mediator.Send(new GetPartialUnitQuery { UserId = this.UserManager.GetUserId(this.User) });

            monster = await this.Mediator.Send(new GenerateMonsterCommand { PlayerLevel = playerPVM.Level, ZoneName = this.zoneName });

            heroId = playerPVM.Id;

            yourTurn = true;

            return this.View(@"\Battle", monster.Name);
        }

        [HttpGet]
        public async Task<IActionResult> Command()
        {
            hero = await this.Mediator.Send(new GetFullUnitQuery { HeroId = heroId });

            var battleUnits = await this.Mediator.Send(new GetBattleUnitsQuery { Hero = hero, Enemy = monster });

            return this.View(@"\Command", battleUnits);
        }

        [HttpPost]
        public async Task<JsonResult> Command([FromForm]string command, [FromForm]int spellId)
        {
            await this.Mediator.Send(new BattleOptionsCommand
            { Command = command, Hero = hero, Enemy = monster, YourTurn = yourTurn, SpellId = spellId, ZoneName = this.zoneName });

            hero = await this.Mediator.Send(new GetFullUnitQuery { HeroId = heroId });
            var battleUnits = await this.Mediator.Send(new GetBattleUnitsQuery { Hero = hero, Enemy = monster });

            return this.Json(new { battleUnits });
        }

        [HttpGet]
        public IActionResult End()
        {
            return this.View(heroId);
        }

        [HttpGet]
        public IActionResult Killed()
        {
            return this.View();
        }
    }
}
