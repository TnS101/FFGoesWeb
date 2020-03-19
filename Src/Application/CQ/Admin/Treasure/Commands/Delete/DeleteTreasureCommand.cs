namespace Application.CQ.Admin.Treasure.Commands.Delete
{
    using MediatR;

    public class DeleteTreasureCommand : IRequest
    {
        public string Id { get; set; }
    }
}
