namespace Application.CQ.Admin.GameContent.Monsters.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.Common.StringProcessing.ImagePaths;
    using Domain.Entities.Game.Units;
    using MediatR;

    public class UpdateMonsterCommandHandler : BaseHandler, IRequestHandler<UpdateMonsterCommand, string>
    {
        private readonly ImagePath imagePath;

        public UpdateMonsterCommandHandler(IFFDbContext context)
            : base(context)
        {
            this.imagePath = new ImagePath();
        }

        public async Task<string> Handle(UpdateMonsterCommand request, CancellationToken cancellationToken)
        {
            var monster = await this.Context.Monsters.FindAsync(request.MonsterId);

            this.StatsNullCheck(request, monster);

            monster.ImagePath = this.imagePath.Process(new string[] { "Monster", monster.Name });

            this.Context.Monsters.Update(monster);

            await this.Context.SaveChangesAsync(cancellationToken);

            return null;
        }

        private void StatsNullCheck(UpdateMonsterCommand request, Monster monster)
        {
            if (!string.IsNullOrWhiteSpace(request.NewName))
            {
                monster.Name = request.NewName;
            }

            if (request.NewMaxHP > 0)
            {
                monster.MaxHP = request.NewMaxHP;
            }

            if (request.NewMaxMana > 0)
            {
                monster.MaxMana = request.NewMaxMana;
            }

            if (request.NewHealthRegen > 0)
            {
                monster.HealthRegen = request.NewHealthRegen;
            }

            if (request.NewManaRegen > 0)
            {
                monster.ManaRegen = request.NewManaRegen;
            }

            if (request.NewAttackPower > 0)
            {
                monster.AttackPower = request.NewAttackPower;
            }

            if (request.NewMagicPower > 0)
            {
                monster.MagicPower = request.NewMagicPower;
            }

            if (request.NewArmorValue > 0)
            {
                monster.ArmorValue = request.NewArmorValue;
            }

            if (request.NewResistanceValue > 0)
            {
                monster.ResistanceValue = request.NewResistanceValue;
            }

            if (request.NewCritChance > 0)
            {
                monster.CritChance = request.NewCritChance;
            }

            if (!string.IsNullOrWhiteSpace(request.NewDescription))
            {
                monster.Description = request.NewDescription;
            }
        }
    }
}
