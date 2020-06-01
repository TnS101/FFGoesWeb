namespace WebUI.Controllers.Game
{
    using System.Threading.Tasks;
    using Application.GameCQ.Battles.Commands.Update;
    using Application.GameCQ.Battles.Queries.GetBattleUnitsQuery;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetPartialUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetUnitIdQuery;
    using Application.GameCQ.Monsters.Commands.Create;
    using Domain.Entities.Game.Units;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class BattleController : BaseController
    {
        private static bool yourTurn;
        private static Monster monster;
        private static UnitFullViewModel hero;
        private static string zoneName;
        private static long heroId;

        [HttpGet("Battle/Battle/zone")]
        public async Task<IActionResult> Battle([FromQuery]string zone)
        {
            zoneName = zone;

            var playerPVM = await this.Mediator.Send(new GetPartialUnitQuery { UserId = this.UserManager.GetUserId(this.User) });

            monster = await this.Mediator.Send(new GenerateMonsterCommand { PlayerLevel = playerPVM.Level, ZoneName = zoneName });

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
        public async Task<IActionResult> Command([FromForm]string command, [FromForm]string spellName)
        {
            hero = await this.Mediator.Send(new GetFullUnitQuery { HeroId = heroId });

            var battleUnits = await this.Mediator.Send(new GetBattleUnitsQuery { Hero = hero, Enemy = monster });

            return this.View(
                await this.Mediator.Send(new BattleOptionsCommand
                { Command = command, Hero = hero, Enemy = monster, YourTurn = yourTurn, SpellName = spellName, ZoneName = zoneName }), battleUnits);
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
