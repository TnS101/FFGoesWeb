namespace Application.CQ.Admin.GameContent.Monsters.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.Common.StringProcessing.ImagePaths;
    using Domain.Entities.Game.Units;
    using global::Common;
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

            return string.Format(GConst.AdminMonsterCommandRedirectId, monster.Id);
        }

        private void StatsNullCheck(UpdateMonsterCommand request, Monster monster)
        {
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                monster.Name = request.Name;
            }

            if (request.MaxHP > 0)
            {
                monster.MaxHP = request.MaxHP;
            }

            if (request.MaxMana > 0)
            {
                monster.MaxMana = request.MaxMana;
            }

            if (request.HealthRegen > 0)
            {
                monster.HealthRegen = request.HealthRegen;
            }

            if (request.ManaRegen > 0)
            {
                monster.ManaRegen = request.ManaRegen;
            }

            if (request.AttackPower > 0)
            {
                monster.AttackPower = request.AttackPower;
            }

            if (request.MagicPower > 0)
            {
                monster.MagicPower = request.MagicPower;
            }

            if (request.ArmorValue > 0)
            {
                monster.ArmorValue = request.ArmorValue;
            }

            if (request.ResistanceValue > 0)
            {
                monster.ResistanceValue = request.ResistanceValue;
            }

            if (request.CritChance > 0)
            {
                monster.CritChance = request.CritChance;
            }

            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                monster.Description = request.Description;
            }

            if (!string.IsNullOrWhiteSpace(request.Zone))
            {
                monster.Zone = request.Zone;
            }
        }
    }
}
