namespace Application.Tests.CQ.Admin.GameContent.FightingClasses.Commands
{
    using Application.CQ.Admin.GameContent.FightingClasses.Commands.Update;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class UpdateFightingClassCommandHandlerTests : CommandTestBase
    {
        private readonly int fightingClassId;
        private readonly UpdateFightingClassCommandHandler sut;

        public UpdateFightingClassCommandHandlerTests()
        {
            this.fightingClassId = CommandArrangeHelper.GetFightingClassId(context);
            this.sut = new UpdateFightingClassCommandHandler(context);
        }

        [Fact]
        public async Task ShouldUpdateFightingClass()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new UpdateFightingClassCommand { FightingClassId = this.fightingClassId,
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
            }, CancellationToken.None));

            var fightingClass = this.context.FightingClasses.FirstOrDefault();

            fightingClass.MaxHP.ShouldBe(100);
            fightingClass.MaxMana.ShouldBe(100);
            fightingClass.HealthRegen.ShouldBe(1);
            fightingClass.ManaRegen.ShouldBe(1);
            fightingClass.AttackPower.ShouldBe(1);
            fightingClass.MagicPower.ShouldBe(1);
            fightingClass.ArmorValue.ShouldBe(1);
            fightingClass.ResistanceValue.ShouldBe(1);
            fightingClass.CritChance.ShouldBe(1);
            fightingClass.Description.ShouldBe("sometext");

            Assert.Equal(GConst.SuccessStatus, status.Status.ToString());
            Assert.Equal(string.Format(GConst.AdminFightingClassCommandRedirectId, 1), status.Result.ToString());
            Assert.Equal(1, this.context.FightingClasses.Count());
        }
    }
}
