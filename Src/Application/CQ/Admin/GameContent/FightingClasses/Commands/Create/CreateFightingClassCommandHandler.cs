namespace Application.CQ.Admin.GameContent.FightingClasses.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.Common.StringProcessing.ImagePaths;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;

    public class CreateFightingClassCommandHandler : BaseHandler, IRequestHandler<CreateFightingClassCommand, string>
    {
        private readonly ImagePath imagePath;

        public CreateFightingClassCommandHandler(IFFDbContext context)
            : base(context)
        {
            this.imagePath = new ImagePath();
        }

        public async Task<string> Handle(CreateFightingClassCommand request, CancellationToken cancellationToken)
        {
            var fightingClass = new FightingClass
            {
                ClassType = request.ClassType,
                MaxHP = request.MaxHP,
                MaxMana = request.MaxMana,
                HealthRegen = request.HealthRegen,
                ManaRegen = request.ManaRegen,
                AttackPower = request.AttackPower,
                MagicPower = request.MagicPower,
                ArmorValue = request.ArmorValue,
                ResistanceValue = request.ResistanceValue,
                CritChance = request.CritChance,
                Description = request.Description,
                IconPath = this.imagePath.IconProcess(request.ClassType),
                ImagePath = this.imagePath.Process(new string[] { "Class", request.ClassType }),
            };

            this.Context.FightingClasses.Add(fightingClass);

            await this.Context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.AdminUnitCommandRedirectId, fightingClass.Id);
        }
    }
}
