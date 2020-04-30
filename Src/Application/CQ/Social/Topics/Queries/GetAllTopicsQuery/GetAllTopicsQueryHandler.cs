namespace Application.CQ.Social.Topics.Queries.GetAllTopicsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllTopicsQueryHandler : BaseHandler, IRequestHandler<GetAllTopicsQuery, TopicListViewModel>
    {
        public GetAllTopicsQueryHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<TopicListViewModel> Handle(GetAllTopicsQuery request, CancellationToken cancellationToken)
        {
            if (request.Filter != null)
            {
                return await this.PublicTopics(request);
            }
            else
            {
                return await this.PersonalTopics(request);
            }
        }

        private async Task<TopicListViewModel> PersonalTopics(GetAllTopicsQuery request)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            return new TopicListViewModel
            {
                Topics = await this.Context.Topics.Where(t => t.UserId == user.Id).Select(t => new TopicPartialViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Category = t.Category,
                    UserName = t.User.UserName,
                    CreateOn = t.CreateOn,
                    Likes = this.Context.Likes.Where(l => l.TopicId == t.Id).ToList(),
                    Comments = t.Comments.Count(),
                    UserId = t.UserId,
                })
            .OrderByDescending(t => t.CreateOn)
            .ToListAsync(),
            };
        }

        private async Task<TopicListViewModel> PublicTopics(GetAllTopicsQuery request)
        {
            var viewer = await this.Context.AppUsers.FindAsync(request.UserId);

            var topics = await this.Context.Topics.Select(t => new TopicPartialViewModel
            {
                Id = t.Id,
                Title = t.Title,
                Category = t.Category,
                UserName = t.User.UserName,
                CreateOn = t.CreateOn,
                Likes = this.Context.Likes.Where(l => l.TopicId == t.Id).ToList(),
                UserId = t.UserId,
                Comments = t.Comments.Count(),
            })
                .OrderByDescending(t => t.CreateOn)
                .ToListAsync();

            if (request.Filter.Count() == 0 || request.Filter.Count() >= 4)
            {
                return new TopicListViewModel
                {
                    Topics = topics,
                    ViewerId = viewer.Id,
                };
            }
            else if (request.Filter.Count() == 1)
            {
                string singleFilter = request.Filter.FirstOrDefault();

                return new TopicListViewModel
                {
                    Topics = topics.Where(t => t.Category == singleFilter),
                    ViewerId = viewer.Id,
                };
            }
            else
            {
                if (request.Filter.Count() == 2)
                {
                    return new TopicListViewModel
                    {
                        Topics = topics.Where(t => t.Category == request.Filter[0] || t.Category == request.Filter[1]),
                        ViewerId = viewer.Id,
                    };
                }
                else
                {
                    return new TopicListViewModel
                    {
                        Topics = topics.Where(t => t.Category == request.Filter[0] || t.Category == request.Filter[1] || t.Category == request.Filter[2]),
                        ViewerId = viewer.Id,
                    };
                }
            }
        }
    }
}
