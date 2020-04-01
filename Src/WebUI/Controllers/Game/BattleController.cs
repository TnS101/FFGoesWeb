﻿namespace WebUI.Controllers.Game
{
    using System.Threading.Tasks;
    using Application.GameCQ.Battles.Commands.Update;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetPartialUnitQuery;
    using Application.GameCQ.Items.Commands.Update;
    using Application.GameCQ.Monsters.Commands.Create;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    // [Authorize(Roles = "Administrator,Player")]
    public class BattleController : BaseController
    {
        private UnitFullViewModel monster;
        private bool yourTurn;
        private UnitFullViewModel player;

        [HttpGet]
        public async Task<ActionResult> Battle()
        {
            var playerPVM = await this.Mediator.Send(new GetPartialUnitQuery { User = this.User });
            this.monster = await this.Mediator.Send(new GenerateMonsterCommand { PlayerLevel = playerPVM.Level });
            this.yourTurn = true;
            return this.View(@"\Battle", this.monster.Name);
        }

        [HttpGet]
        public async Task<ActionResult> Action()
        {
            this.player = await this.Mediator.Send(new GetFullUnitQuery { User = this.User });
            return this.View(@"\Action", this.Stats(this.player));
        }

        [HttpPost]
        public async Task<ActionResult> Action([FromForm]string command, [FromForm]string spellName)
        {
            this.player = await this.Mediator.Send(new GetFullUnitQuery { User = this.User });

            return this.View(
                await this.Mediator.Send(new BattleOptionsCommand
            { Command = command, Player = this.player, Enemy = this.monster, YourTurn = this.yourTurn, SpellName = spellName }), this.Stats(this.player));
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
