namespace WebUI.Controllers.Game
{
    using System.Threading.Tasks;
    using Application.GameCQ.Battles.Commands.Update;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetPartialUnitQuery;
    using Application.GameCQ.Items.Commands.Update;
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

        [HttpGet("Battle/Battle/zone")]
        public async Task<ActionResult> Battle([FromQuery]string zone)
        {
            zoneName = zone;
            var playerPVM = await this.Mediator.Send(new GetPartialUnitQuery { User = this.User });
            monster = await this.Mediator.Send(new GenerateMonsterCommand { PlayerLevel = playerPVM.Level, ZoneName = zoneName });
            yourTurn = true;
            return this.View(@"\Battle", monster.Name);
        }

        [HttpGet]
        public async Task<ActionResult> Command()
        {
            hero = await this.Mediator.Send(new GetFullUnitQuery { User = this.User });

            return this.View(@"\Command", this.Stats(hero));
        }

        [HttpGet("Battle/Command/command")]
        public async Task<ActionResult> Command([FromQuery]string command, [FromQuery]string spellName)
        {
            hero = await this.Mediator.Send(new GetFullUnitQuery { User = this.User });

            return this.View(
                await this.Mediator.Send(new BattleOptionsCommand
                { Command = command, Player = hero, Enemy = monster, YourTurn = yourTurn, SpellName = spellName, ZoneName = zoneName }), this.Stats(hero));
        }

        [HttpGet]
        public async Task<ActionResult> End()
        {
            return this.View(await this.Mediator.Send(new LootItemCommand { MonsterId = monster.Id, }));
        }

        private string[] Stats(UnitFullViewModel playerFullVm)
        {
            return new string[]
            {
                playerFullVm.Name, monster.Name, monster.ImageURL,
                playerFullVm.CurrentHP.ToString(), playerFullVm.MaxHP.ToString(), monster.CurrentHP.ToString(), monster.MaxHP.ToString(),
                playerFullVm.CurrentAttackPower.ToString(), monster.CurrentAttackPower.ToString(), playerFullVm.CurrentMana.ToString(),
                playerFullVm.MaxMana.ToString(), monster.MaxMana.ToString(), playerFullVm.MagicPower.ToString(),
                playerFullVm.CurrentMagicPower.ToString(), monster.MagicPower.ToString(), monster.CurrentMagicPower.ToString(), playerFullVm.ImageURL,
                playerFullVm.ClassType,
            };
        }
    }
}
