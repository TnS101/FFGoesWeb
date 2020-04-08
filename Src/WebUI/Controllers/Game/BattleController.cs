namespace WebUI.Controllers.Game
{
    using System.Threading.Tasks;
    using Application.GameCQ.Battles.Commands.Update;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetPartialUnitQuery;
    using Application.GameCQ.Items.Commands.Update;
    using Application.GameCQ.Monsters.Commands.Create;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class BattleController : BaseController
    {
        private UnitFullViewModel monster;
        private bool yourTurn;
        private UnitFullViewModel hero;

        [HttpGet("Battle/Battle/zone")]
        public async Task<ActionResult> Battle([FromQuery]string zone)
        {
            var playerPVM = await this.Mediator.Send(new GetPartialUnitQuery { User = this.User });
            this.monster = await this.Mediator.Send(new GenerateMonsterCommand { PlayerLevel = playerPVM.Level, ZoneName = zone });
            this.yourTurn = true;
            return this.View(@"\Battle", this.monster.Name);
        }

        [HttpGet]
        public async Task<ActionResult> Command()
        {
            this.hero = await this.Mediator.Send(new GetFullUnitQuery { User = this.User });

            return this.View(@"\Command", this.Stats(this.hero));
        }

        [HttpPost("Battle/Action/command")]
        public async Task<ActionResult> Command([FromQuery]string command, [FromQuery]string spellName)
        {
            return this.View(
                await this.Mediator.Send(new BattleOptionsCommand
            { Command = command, Player = this.hero, Enemy = this.monster, YourTurn = this.yourTurn, SpellName = spellName }), this.Stats(this.hero));
        }

        [HttpGet]
        public async Task<ActionResult> End()
        {
            return this.View(await this.Mediator.Send(new LootItemCommand { MonsterId = int.Parse(this.monster.Id),  }));
        }

        private string[] Stats(UnitFullViewModel playerFullVm)
        {
            return new string[]
            {
                playerFullVm.Name, this.monster.Name, this.monster.ImageURL,
                playerFullVm.CurrentHP.ToString(), playerFullVm.MaxHP.ToString(), this.monster.CurrentHP.ToString(), this.monster.MaxHP.ToString(),
                playerFullVm.CurrentAttackPower.ToString(), this.monster.CurrentAttackPower.ToString(), playerFullVm.CurrentMana.ToString(),
                playerFullVm.MaxMana.ToString(), this.monster.CurrentMana.ToString(), this.monster.MaxMana.ToString(), playerFullVm.MagicPower.ToString(),
                playerFullVm.CurrentMagicPower.ToString(), this.monster.MagicPower.ToString(), this.monster.CurrentMagicPower.ToString(),
            };
        }
    }
}
