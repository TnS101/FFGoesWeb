namespace Application.CQ.Forum.Topic.Queries.GetAllTopicsQuery
{
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllTopicsQueryHandler : IRequestHandler<GetAllTopicsQuery, TopicListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public GetAllTopicsQueryHandler(IFFDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<TopicListViewModel> Handle(GetAllTopicsQuery request, CancellationToken cancellationToken)
        {
            if (request.User is null)
            {
                return new TopicListViewModel
                {
                    Topics = await this.context.Topics.Select(t => new TopicPartialViewModel
                    {
                        Title = t.Title,
                        Category = t.Category,
                        UserName = t.User.UserName,
                        CreateOn = t.CreateOn,
                        Likes = t.Likes,
                        Comments = t.Comments.Count()
                    })
                .OrderByDescending(t => t.CreateOn)
                .ToListAsync()
                };
            }
            else
            {
                var user = await this.userManager.GetUserAsync(request.User);

                return new TopicListViewModel
                {
                    Topics = await this.context.Topics.Where(t => t.UserId == user.Id).Select(t => new TopicPartialViewModel
                    {
                        Title = t.Title,
                        Category = t.Category,
                        UserName = t.User.UserName,
                        CreateOn = t.CreateOn,
                        Likes = t.Likes,
                        Comments = t.Comments.Count()
                    })
                .OrderByDescending(t => t.CreateOn)
                .ToListAsync()
                };
            }
        }
    }
}
