namespace Application.GameCQ.Unit.Queries
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUnitQueryHandler : IRequestHandler<GetUnitQuery, UnitViewModel>
    {
        private readonly IFFDbContext context;
        public GetUnitQueryHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<UnitViewModel> Handle(GetUnitQuery request, CancellationToken cancellationToken)
        {
            var unit = await this.context.Units.FindAsync(request.UnitId);

            return new UnitViewModel
            {
                ArmorValue = unit.ArmorValue,
                AttackPower = unit.AttackPower,
                ClassType = unit.ClassType,
                Level = unit.Level,
                MagicPower = unit.MagicPower,
                Name = unit.Name,
                Race = unit.Race,
                RessistanceValue = unit.RessistanceValue
            };
        }
    }
}
