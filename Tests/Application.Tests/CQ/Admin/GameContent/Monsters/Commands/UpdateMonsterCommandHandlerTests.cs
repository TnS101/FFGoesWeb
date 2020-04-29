namespace Application.Tests.CQ.Admin.GameContent.Monsters.Commands
{
    using Application.CQ.Admin.GameContent.Monsters.Commands.Update;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class UpdateMonsterCommandHandlerTests : CommandTestBase
    {
        private readonly int monsterId;
        private readonly UpdateMonsterCommandHandler sut;

        public UpdateMonsterCommandHandlerTests()
        {
            this.sut = new UpdateMonsterCommandHandler(context);
            this.monsterId = CommandArrangeHelper.GetMonsterId(context);
        }

        [Fact]
        public async Task ShouldUpdateMonster()
        {
            var result = await this.sut.Handle(new UpdateMonsterCommand { MonsterId = this.monsterId,
                NewMaxHP = 100,
                NewMaxMana = 100,
                NewHealthRegen = 1,
                NewManaRegen = 1,
                NewAttackPower = 1,
                NewMagicPower = 1,
                NewArmorValue = 1,
                NewResistanceValue = 1,
                NewCritChance = 1,
                NewDescription = "sometext",
            }, CancellationToken.None);

            var monster = this.context.Monsters.FirstOrDefault();

            monster.MaxHP.ShouldBe(100);
            monster.MaxMana.ShouldBe(100);
            monster.HealthRegen.ShouldBe(1);
            monster.ManaRegen.ShouldBe(1);
            monster.AttackPower.ShouldBe(1);
            monster.MagicPower.ShouldBe(1);
            monster.ArmorValue.ShouldBe(1);
            monster.ResistanceValue.ShouldBe(1);
            monster.CritChance.ShouldBe(1);
            monster.Description.ShouldBe("sometext");

            result.ShouldBe(string.Format(GConst.AdminMonsterCommandRedirectId, this.monsterId));
        }
    }
}
