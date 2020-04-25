namespace Application.CQ.Admin.GameContent.Monsters.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.Common.StringProcessing.ImagePaths;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;

    public class CreateMonsterCommandHandler : BaseHandler, IRequestHandler<CreateMonsterCommand, string>
    {
        private readonly ImagePath imagePath;

        public CreateMonsterCommandHandler(IFFDbContext context)
            : base(context)
        {
            this.imagePath = new ImagePath();
        }

        public async Task<string> Handle(CreateMonsterCommand request, CancellationToken cancellationToken)
        {
            var monster = new Monster
            {
                Name = request.Name,
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
                ImagePath = this.imagePath.Process(new string[] { "Monster", request.Name }),
            };

            this.Context.Monsters.Add(monster);

            await this.Context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.AdminMonsterCommandRedirectId, monster.Id);
        }
    }
}
