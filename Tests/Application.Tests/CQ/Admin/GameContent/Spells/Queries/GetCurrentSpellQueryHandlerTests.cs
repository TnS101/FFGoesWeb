namespace Application.Tests.CQ.Admin.GameContent.Spells.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.CQ.Admin.GameContent.Spells.Queries.GetCurrentSpellQuery;
    using Application.Tests.Infrastructure;
    using Shouldly;
    using Xunit;

    public class GetCurrentSpellQueryHandlerTests : QueryTestFixture
    {
        private readonly int spellId;
        private readonly GetCurrentSpellQueryHandler sut;

        public GetCurrentSpellQueryHandlerTests()
        {
            this.spellId = CommandArrangeHelper.GetSpellId(context);
            this.sut = new GetCurrentSpellQueryHandler(context, mapper);
        }

        [Fact]
        public async Task ShouldGetCurrentSpell()
        {
            var result = await this.sut.Handle(new GetCurrentSpellQuery { SpellId = this.spellId }, CancellationToken.None);

            result.Id.ShouldBe(1);

            result.ClassType.ShouldBe("1");
            result.ClassType.ShouldNotBeNull();
            result.EffectPower.ShouldBe(1);
            result.EffectPower.ShouldNotBeNull();
            result.AdditionalEffect.ShouldBe("1");
            result.AdditionalEffect.ShouldNotBeNull();
            result.BuffOrEffectTarget.ShouldBe("1");
            result.BuffOrEffectTarget.ShouldNotBeNull();
            result.ManaRequirement.ShouldBe(10);
            result.ManaRequirement.ShouldNotBeNull();
            result.Name.ShouldBe("1");
            result.Name.ShouldNotBeNull();
            result.ResistanceAffect.ShouldBe(1);
            result.ResistanceAffect.ShouldNotBeNull();
            result.SecondaryPower.ShouldBe(10);
            result.SecondaryPower.ShouldNotBeNull();
            result.Power.ShouldBe(1);
            result.Power.ShouldNotBeNull();
            result.Type.ShouldBe("1");
            result.Type.ShouldNotBeNull();

            result.ShouldBeOfType<SpellFullViewModel>();
            result.ShouldNotBeNull();
        }
    }
}
