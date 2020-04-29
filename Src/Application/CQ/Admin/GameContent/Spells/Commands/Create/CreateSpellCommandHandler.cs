namespace Application.CQ.Admin.GameContent.Spells.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;

    public class CreateSpellCommandHandler : BaseHandler, IRequestHandler<CreateSpellCommand, string>
    {
        public CreateSpellCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(CreateSpellCommand request, CancellationToken cancellationToken)
        {
            this.Context.Spells.Add(new Spell
            {
                Name = request.Name,
                ManaRequirement = request.ManaRequirement,
                ClassType = request.ClassType,
                Type = request.Type,
                Power = request.Power,
                SecondaryPower = request.SecondaryPower,
                AdditionalEffect = request.AdditionalEffect,
                EffectPower = request.EffectPower,
                BuffOrEffectTarget = request.BuffOrEffectTarget,
                ResistanceAffect = request.ResistanceAffect,
            });

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.AdminSpellCommandRedirect;
        }
    }
}
