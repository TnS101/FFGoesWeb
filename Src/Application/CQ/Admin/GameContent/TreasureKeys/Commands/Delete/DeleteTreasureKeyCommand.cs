namespace Application.CQ.Admin.TreasureKey.Commands.Delete
{
    using MediatR;

    public class DeleteTreasureKeyCommand : IRequest<string>
    {
        public string KeyId { get; set; }
    }
}
