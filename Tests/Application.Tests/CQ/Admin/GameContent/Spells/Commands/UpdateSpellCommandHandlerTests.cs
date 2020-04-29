namespace Application.Tests.CQ.Admin.GameContent.Spells.Commands
{
    using Application.CQ.Admin.GameContent.Spells.Commands.Update;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class UpdateSpellCommandHandlerTests : CommandTestBase
    {
        private readonly int spellId;
        private readonly UpdateSpellCommandHandler sut;

        public UpdateSpellCommandHandlerTests()
        {
            this.sut = new UpdateSpellCommandHandler(context);
            this.spellId = CommandArrangeHelper.GetSpellId(context);
        }

        [Fact]
        public async Task ShouldUpdateSpell()
        {
            var result = await this.sut.Handle(new UpdateSpellCommand { SpellId = this.spellId,
               NewClassType = "1",
               NewSecondaryPower = 1,
               NewAdditionalEffect = "1",
               NewBuffOrEffectTarget = "1",
               NewEffectPower = 1,
               NewManaRequirement = 1,
               NewName = "1",
               NewPower = 1,
               NewResistanceAffect = 1,
               NewType = "1",
            }, CancellationToken.None);

            var spell = this.context.Spells.FirstOrDefault();

            spell.ClassType.ShouldBe("1");
            spell.SecondaryPower.ShouldBe(1);
            spell.AdditionalEffect.ShouldBe("1");
            spell.BuffOrEffectTarget.ShouldBe("1");
            spell.EffectPower.ShouldBe(1);
            spell.ManaRequirement.ShouldBe(1);
            spell.Name.ShouldBe("1");
            spell.Power.ShouldBe(1);
            spell.ResistanceAffect.ShouldBe(1);
            spell.Type.ShouldBe("1");

            result.ShouldBe(GConst.AdminSpellCommandRedirect);
        }
    }
}
