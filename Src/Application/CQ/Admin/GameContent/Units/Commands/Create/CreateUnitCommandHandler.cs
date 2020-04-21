namespace Application.CQ.Admin.GameContent.Units.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.Common.StringProcessing.ImagePaths;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;

    public class CreateUnitCommandHandler : IRequestHandler<CreateUnitCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly ImagePath imagePath;

        public CreateUnitCommandHandler(IFFDbContext context)
        {
            this.context = context;
            this.imagePath = new ImagePath();
        }

        public async Task<string> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            string returnString;

            if (request.UnitType == "Monster")
            {
                var monster = new Monster
                {
                    Name = request.Name,
                    Type = request.UnitType,
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
                    ImagePath = this.imagePath.Process(new string[] { request.UnitType, request.Name }),
                };

                await this.context.Monsters.AddAsync(monster);

                await this.context.SaveChangesAsync(cancellationToken);

                returnString = string.Format(GConst.MonsterCommandRedirectId, monster.Id);
            }
            else
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
                    ImagePath = this.imagePath.Process(new string[] { request.UnitType, request.Name }),
                };

                await this.context.FightingClasses.AddAsync(fightingClass);

                await this.context.SaveChangesAsync(cancellationToken);

                returnString = string.Format(GConst.AdminUnitCommandRedirectId, fightingClass.Id);
            }

            return returnString;
        }
    }
}
