namespace Application.CQ.Admin.GameContent.FightingClasses.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Units;
    using MediatR;

    public class UpdateFightingClassCommandHandler : BaseHandler, IRequestHandler<UpdateFightingClassCommand, string>
    {
        public UpdateFightingClassCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(UpdateFightingClassCommand request, CancellationToken cancellationToken)
        {
            var fightingClass = await this.Context.FightingClasses.FindAsync(request.FightingClassId);

            this.StatsNullCheck(request, fightingClass);

            this.Context.FightingClasses.Update(fightingClass);

            await this.Context.SaveChangesAsync(cancellationToken);

            return null;
        }

        private void StatsNullCheck(UpdateFightingClassCommand request, FightingClass fightingClass)
        {
            if (!string.IsNullOrWhiteSpace(request.NewClassStype))
            {
                fightingClass.ClassType = request.NewClassStype;
            }

            if (request.NewMaxHP > 0)
            {
                fightingClass.MaxHP = request.NewMaxHP;
            }

            if (request.NewMaxMana > 0)
            {
                fightingClass.MaxMana = request.NewMaxMana;
            }

            if (request.NewHealthRegen > 0)
            {
                fightingClass.HealthRegen = request.NewHealthRegen;
            }

            if (request.NewManaRegen > 0)
            {
                fightingClass.ManaRegen = request.NewManaRegen;
            }

            if (request.NewAttackPower > 0)
            {
                fightingClass.AttackPower = request.NewAttackPower;
            }

            if (request.NewMagicPower > 0)
            {
                fightingClass.MagicPower = request.NewMagicPower;
            }

            if (request.NewArmorValue > 0)
            {
                fightingClass.ArmorValue = request.NewArmorValue;
            }

            if (request.NewResistanceValue > 0)
            {
                fightingClass.ResistanceValue = request.NewResistanceValue;
            }

            if (request.NewCritChance > 0)
            {
                fightingClass.CritChance = request.NewCritChance;
            }

            if (!string.IsNullOrWhiteSpace(request.NewDescription))
            {
                fightingClass.Description = request.NewDescription;
            }
        }
    }
}
