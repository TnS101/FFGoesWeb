namespace Application.CQ.Forum.Topic.Queries.GetAllTopicsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetAllTopicsQueryHandler : IRequestHandler<GetAllTopicsQuery, TopicListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public GetAllTopicsQueryHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<TopicListViewModel> Handle(GetAllTopicsQuery request, CancellationToken cancellationToken)
        {
            if (request.User is null)
            {
                return await this.PublicTopics();
            }
            else
            {
                return await this.PersonalTopics(request);
            }
        }

        private async Task<TopicListViewModel> PersonalTopics(GetAllTopicsQuery request)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            return new TopicListViewModel
            {
                Topics = await this.context.Topics.Where(t => t.UserId == user.Id).Select(t => new TopicPartialViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Category = t.Category,
                    UserName = t.User.UserName,
                    CreateOn = t.CreateOn,
                    Likes = t.Likes,
                    Comments = t.Comments.Count(),
                    UserId = t.UserId,
                })
            .OrderByDescending(t => t.CreateOn)
            .ToListAsync(),
            };
        }

        private async Task<TopicListViewModel> PublicTopics()
        {
            return new TopicListViewModel
            {
                Topics = await this.context.Topics.Select(t => new TopicPartialViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Category = t.Category,
                    UserName = t.User.UserName,
                    CreateOn = t.CreateOn,
                    Likes = t.Likes,
                    Comments = t.Comments.Count(),
                })
                .OrderByDescending(t => t.CreateOn)
                .ToListAsync(),
            };
        }
    }
}
