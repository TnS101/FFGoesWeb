namespace Application.GameCQ.Treasure.Commands.Delete
{
    using MediatR;

    public class DeleteTreasureCommand : IRequest
    {
        public int Id { get; set; }
    }
}
