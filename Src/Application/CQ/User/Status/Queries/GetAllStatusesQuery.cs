namespace Application.CQ.User.Status.Queries
{
    using MediatR;

    public class GetAllStatusesQuery : IRequest<StatusListViewModel>
    {
    }
}
