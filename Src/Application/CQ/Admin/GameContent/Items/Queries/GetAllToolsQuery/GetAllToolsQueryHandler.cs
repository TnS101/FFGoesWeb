namespace Application.CQ.Admin.GameContent.Items.Queries.GetAllToolsQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllToolsQueryHandler : MapperHandler, IRequestHandler<GetAllToolsQuery, ToolsListViewModel>
    {
        public GetAllToolsQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<ToolsListViewModel> Handle(GetAllToolsQuery request, CancellationToken cancellationToken)
        {
            return new ToolsListViewModel
            {
                Tools = await this.Context.Tools.ProjectTo<ToolMinViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync(),
            };
        }
    }
}
