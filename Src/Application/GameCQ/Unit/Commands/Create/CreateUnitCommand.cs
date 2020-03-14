namespace Application.GameCQ.Unit.Commands.Create
{
    using MediatR;

    public class CreateUnitCommand : IRequest
    {
        public int UserId { get; set; }

        public string ClassType { get; set; }

        public string Race { get; set; }

        public string Name { get; set; }
    }
}
