namespace Application.Tests.CQ.Admin.GameContent.Monsters.Commands
{
    using Application.CQ.Admin.GameContent.Monsters.Commands.Create;
    using Application.Tests.Infrastructure;
    using global::Common;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class CreateMonsterCommandHandlerTests : CommandTestBase
    {
        private readonly CreateMonsterCommandHandler sut;

        public CreateMonsterCommandHandlerTests()
        {
            this.sut = new CreateMonsterCommandHandler(context);
        }

        [Fact]
        public async Task ShouldCreateMonster()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(
                new CreateMonsterCommand
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
            Assert.Equal(string.Format(GConst.AdminMonsterCommandRedirectId, 1), status.Result.ToString());
            Assert.Equal(1, this.context.Monsters.Count());
        }
    }
}
