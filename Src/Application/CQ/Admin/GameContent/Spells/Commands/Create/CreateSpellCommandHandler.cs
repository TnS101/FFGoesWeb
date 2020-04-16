namespace Application.CQ.Admin.GameContent.Spells.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;

    public class CreateSpellCommandHandler : IRequestHandler<CreateSpellCommand, string>
    {
        private readonly IFFDbContext context;

        public CreateSpellCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(CreateSpellCommand request, CancellationToken cancellationToken)
        {
            await this.context.Spells.AddAsync(new Spell
            {
                Name = request.Name,
                ManaRequirement = 0.2,
                ClassType = request.ClassType,
                Type = request.Type,
                Power = request.Power,
                SecondaryPower = request.SecondaryPower,
                AdditionalEffect = request.AdditionalEffect,
                EffectPower = request.EffectPower,
                BuffOrEffectTarget = request.BuffOrEffectTarget,
                ResistanceAffect = request.ResistanceAffect,
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.SpellCommandRedirect;
        }
    }
}
