namespace Application.Tests.CQ.Admin.GameContent.FightingClasses.Commands
{
    using Application.CQ.Admin.GameContent.FightingClasses.Commands.Create;
    using Application.Tests.Infrastructure;
    using global::Common;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class CreateFightingClassCommandHandlerTests : CommandTestBase
    {
        private readonly CreateFightingClassCommandHandler sut;

        public CreateFightingClassCommandHandlerTests()
        {
            this.sut = new CreateFightingClassCommandHandler(context);
        }

        [Fact]
        public async Task ShouldCreateFightingClass()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(
                new CreateFightingClassCommand
            {
                MaxHP = 100,
                MaxMana = 100,
                HealthRegen = 1,
                ManaRegen = 1,
                AttackPower = 10,
                MagicPower = 10,
                ArmorValue = 2,
                ResistanceValue = 2,
                CritChance = 5,
                Description = "sometext",
            }, CancellationToken.None));

            Assert.Equal(GConst.SuccessStatus, status.Status.ToString());
            Assert.Equal(string.Format(GConst.AdminFightingClassCommandRedirectId, 1), status.Result.ToString());
            Assert.Equal(1, this.context.FightingClasses.Count());
        }
    }
}
