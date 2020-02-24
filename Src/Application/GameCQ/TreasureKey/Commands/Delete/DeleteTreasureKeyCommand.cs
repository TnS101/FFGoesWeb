namespace Application.GameCQ.TreasureKey.Commands.Delete
{
    using MediatR;

    public class DeleteTreasureKeyCommand : IRequest
    {
        public int KeyId { get; set; }
    }
}
