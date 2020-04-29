namespace Application.Tests.CQ.Admin.GameContent.Spells.Commands
{
    using Application.CQ.Admin.GameContent.Spells.Commands.Create;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class CreateSpellCommandHandlerTests : CommandTestBase
    {
        private CreateSpellCommandHandler sut;

        public CreateSpellCommandHandlerTests()
        {
            this.sut = new CreateSpellCommandHandler(context);
            QueryArrangeHelper.AddFightingClasses(context);
        }

        [Fact]
        public async Task ShouldCreateSpell()
        {
            await this.Status();
        }

        private async Task Status()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new CreateSpellCommand 
            { ClassType = "1",
            SecondaryPower = 1,
            AdditionalEffect = "1",
            BuffOrEffectTarget = "1",
            EffectPower = 1,
            ManaRequirement = 1,
            Name = "1",
            Power = 1,
            ResistanceAffect = 1,
            Type = "1",
            }, CancellationToken.None));

            status.Status.ToString().ShouldBe(GConst.SuccessStatus);
            status.Result.ToString().ShouldBe(GConst.AdminSpellCommandRedirect);

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

            this.context.Spells.Count().ShouldBe(1);
        }
    }
}
