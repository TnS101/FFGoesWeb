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
            .AsNoTracking()
            .ToArrayAsync(),
            };
        }

        private async Task<TopicListViewModel> PublicTopics(GetAllTopicsQuery request)
        {
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
                .AsNoTracking()
                .ToArrayAsync();

            if (request.Filter.Count() == 0 || request.Filter.Count() >= 4)
            {
                return new TopicListViewModel
                {
                    Topics = topics,
                    ViewerId = request.UserId,
                };
            }
            else if (request.Filter.Count() == 1)
            {
                string singleFilter = request.Filter[0];

                var singleFilterTopics = await this.Context.Topics.Select(t => new TopicPartialViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Category = singleFilter,
                    UserName = t.User.UserName,
                    CreateOn = t.CreateOn,
                    Likes = this.Context.Likes.Where(l => l.TopicId == t.Id).ToList(),
                    UserId = t.UserId,
                    Comments = t.Comments.Count(),
                })
                .OrderByDescending(t => t.CreateOn)
                .AsNoTracking()
                .ToArrayAsync();

                return new TopicListViewModel
                {
                    Topics = singleFilterTopics,
                    ViewerId = request.UserId,
                };
            }
            else
            {
                if (request.Filter.Count() == 2)
                {
                    var duoFilterTopics = await this.Context.Topics.Where(c => c.Category == request.Filter[0] || c.Category == request.Filter[1]).Select(t => new TopicPartialViewModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        UserName = t.User.UserName,
                        CreateOn = t.CreateOn,
                        Likes = this.Context.Likes.Where(l => l.TopicId == t.Id).ToList(),
                        UserId = t.UserId,
                        Comments = t.Comments.Count(),
                    })
                    .OrderByDescending(t => t.CreateOn)
                    .AsNoTracking()
                    .ToArrayAsync();

                    return new TopicListViewModel
                    {
                        Topics = duoFilterTopics,
                        ViewerId = request.UserId,
                    };
                }
                else
                {
                    var multiFilterTopics = await this.Context.Topics.Where(c => c.Category == request.Filter[0] || c.Category == request.Filter[1] || c.Category == request.Filter[2])
                        .Select(t => new TopicPartialViewModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        UserName = t.User.UserName,
                        CreateOn = t.CreateOn,
                        Likes = this.Context.Likes.Where(l => l.TopicId == t.Id).ToList(),
                        UserId = t.UserId,
                        Comments = t.Comments.Count(),
                    })
                    .OrderByDescending(t => t.CreateOn)
                    .AsNoTracking()
                    .ToArrayAsync();

                    return new TopicListViewModel
                    {
                        Topics = multiFilterTopics,
                        ViewerId = request.UserId,
                    };
                }
            }
        }
    }
}
