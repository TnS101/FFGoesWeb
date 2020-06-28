namespace WebUI.Controllers.Game
{
    using System.Threading.Tasks;
    using Application.GameCQ.Battles.Commands.Delete;
    using Application.GameCQ.Battles.Commands.Update;
    using Application.GameCQ.Battles.Queries.GetBattleUnitsQuery;
    using Application.GameCQ.Heroes.Queries.GetPartialUnitQuery;
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
        private static long heroId;
        private static string zoneName;
        private static int turnCount;

        [HttpGet]
        public async Task<IActionResult> Battle([FromQuery]string zone)
        {
            var playerPVM = await this.Mediator.Send(new GetPartialUnitQuery { UserId = this.UserManager.GetUserId(this.User) });

            monster = await this.Mediator.Send(new GenerateMonsterCommand { PlayerLevel = playerPVM.Level, ZoneName = zoneName });
            heroId = playerPVM.Id;
            yourTurn = true;
            zoneName = zone;
            turnCount = 0;

            return this.View(GConst.Battle, monster.Name);
        }

        [HttpGet]
        public async Task<IActionResult> Command()
        {
            var battleUnits = await this.Mediator.Send(new GetBattleUnitsQuery { HeroId = heroId, Enemy = monster });

            if (monster.CurrentHP <= 0)
            {
                return this.Redirect("/Hero/All");
            }

            return this.View(GConst.BattleCommand, battleUnits);
        }

        [HttpPost]
        public async Task<IActionResult> Command([FromForm]string command, [FromForm]int spellId)
        {
            await this.Mediator.Send(new BattleOptionsCommand
            { Command = command, HeroId = heroId, Enemy = monster, YourTurn = yourTurn, SpellId = spellId, ZoneName = zoneName, TurnCount = turnCount });

            var battleUnits = await this.Mediator.Send(new GetBattleUnitsQuery { HeroId = heroId, Enemy = monster });

            return this.Json(new { battleUnits });
        }

        [HttpGet]
        public async Task<IActionResult> End()
        {
            return this.View(await this.Mediator.Send(new EndBattleCommand { HeroId = heroId, Monster = monster, ZoneName = zoneName }));
        }
    }
}
