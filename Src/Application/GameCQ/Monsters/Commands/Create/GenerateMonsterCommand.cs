namespace Application.GameCQ.Monsters.Commands.Create
{
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using MediatR;

    public class GenerateMonsterCommand : IRequest<UnitFullViewModel>
    {
        public int PlayerLevel { get; set; }

        public string ZoneName { get; set; }
    }
}
