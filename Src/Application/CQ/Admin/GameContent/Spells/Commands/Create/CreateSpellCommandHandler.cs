﻿namespace Application.CQ.Admin.GameContent.Spells.Commands.Create
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
            var spell = new Spell
            {
                Name = request.Name,
                ManaRequirement = request.ManaRequirement,
                Type = request.Type,
                Power = request.Power,
                SecondaryPower = request.SecondaryPower,
                AdditionalEffect = request.AdditionalEffect,
                EffectPower = request.EffectPower,
                BuffOrEffectTarget = request.BuffOrEffectTarget,
                ResistanceAffect = request.ResistanceAffect,
            };

            if (request.IsForPlayer)
            {
                spell.FightingClassId = request.OwnerId;
            }
            else
            {
                spell.MonsterId = request.OwnerId;
            }

            this.Context.Spells.Add(spell);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.AdminSpellCommandRedirect;
        }
    }
}
