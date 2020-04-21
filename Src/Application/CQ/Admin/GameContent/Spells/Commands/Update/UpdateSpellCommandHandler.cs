namespace Application.CQ.Admin.GameContent.Spells.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;

    public class UpdateSpellCommandHandler : IRequestHandler<UpdateSpellCommand, string>
    {
        private readonly IFFDbContext context;

        public UpdateSpellCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(UpdateSpellCommand request, CancellationToken cancellationToken)
        {
            var spellToUpdate = await this.context.Spells.FindAsync(request.SpellId);

            this.NullCheck(request, spellToUpdate);

            this.context.Spells.Update(spellToUpdate);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.AdminSpellCommandRedirect;
        }

        private void NullCheck(UpdateSpellCommand request, Spell spellToUpdate)
        {
            if (!string.IsNullOrWhiteSpace(request.NewName))
            {
                spellToUpdate.Name = request.NewName;
            }

            if (!string.IsNullOrWhiteSpace(request.NewType))
            {
                spellToUpdate.Type = request.NewType;
            }

            if (!string.IsNullOrWhiteSpace(request.NewBuffOrEffectTarget))
            {
                spellToUpdate.BuffOrEffectTarget = request.NewBuffOrEffectTarget;
            }

            if (request.NewPower > 0)
            {
                spellToUpdate.Power = request.NewPower;
            }

            if (request.NewManaRequirement > 0)
            {
                spellToUpdate.ManaRequirement = request.NewManaRequirement;
            }

            if (!string.IsNullOrWhiteSpace(request.NewAdditionalEffect))
            {
                spellToUpdate.AdditionalEffect = request.NewAdditionalEffect;
            }

            if (request.NewEffectPower > 0)
            {
                spellToUpdate.EffectPower = request.NewEffectPower;
            }

            if (!string.IsNullOrWhiteSpace(request.NewClassType))
            {
                spellToUpdate.ClassType = request.NewClassType;
            }

            if (request.NewResistanceAffect > 0)
            {
                spellToUpdate.ResistanceAffect = request.NewResistanceAffect;
            }

            if (request.NewSecondaryPower > 0)
            {
                spellToUpdate.SecondaryPower = request.NewSecondaryPower;
            }
        }
    }
}
