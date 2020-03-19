namespace Application.CQ.Admin.TreasureKey.Commands.Delete
{
    using MediatR;

    public class DeleteTreasureKeyCommand : IRequest
    {
        public string KeyId { get; set; }
    }
}
