﻿namespace Application.CQ.Admin.GameContent.Spells.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;

    public class UpdateSpellCommandHandler : BaseHandler, IRequestHandler<UpdateSpellCommand, string>
    {
        public UpdateSpellCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(UpdateSpellCommand request, CancellationToken cancellationToken)
        {
            var spellToUpdate = await this.Context.Spells.FindAsync(request.SpellId);

            this.NullCheck(request, spellToUpdate);

            this.Context.Spells.Update(spellToUpdate);

            await this.Context.SaveChangesAsync(cancellationToken);

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
