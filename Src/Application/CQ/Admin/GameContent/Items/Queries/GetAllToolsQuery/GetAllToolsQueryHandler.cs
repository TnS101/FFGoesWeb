namespace Application.CQ.Admin.GameContent.Items.Queries.GetAllToolsQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllToolsQueryHandler : IRequestHandler<GetAllToolsQuery, ToolsListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetAllToolsQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ToolsListViewModel> Handle(GetAllToolsQuery request, CancellationToken cancellationToken)
        {
            return new ToolsListViewModel
            {
                Tools = await this.context.Tools.ProjectTo<ToolMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
