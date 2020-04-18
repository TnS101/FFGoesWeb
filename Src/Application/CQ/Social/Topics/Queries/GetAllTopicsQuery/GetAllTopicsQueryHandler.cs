﻿namespace Application.CQ.Social.Topics.Queries.GetAllTopicsQuery
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
                return await this.PublicTopics(request);
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

        private async Task<TopicListViewModel> PublicTopics(GetAllTopicsQuery request)
        {
            var topics = await this.context.Topics.Select(t => new TopicPartialViewModel
            {
                Id = t.Id,
                Title = t.Title,
                Category = t.Category,
                UserName = t.User.UserName,
                CreateOn = t.CreateOn,
                Likes = t.Likes,
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
                };
            }
            else if (request.Filter.Count() == 1)
            {
                string singleFilter = request.Filter.FirstOrDefault();

                return new TopicListViewModel
                {
                    Topics = topics.Where(t => t.Category == singleFilter),
                };
            }
            else
            {
                if (request.Filter.Count() == 2)
                {
                    return new TopicListViewModel
                    {
                        Topics = topics.Where(t => t.Category == request.Filter[0] || t.Category == request.Filter[1]),
                    };
                }
                else
                {
                    return new TopicListViewModel
                    {
                        Topics = topics.Where(t => t.Category == request.Filter[0] || t.Category == request.Filter[1] || t.Category == request.Filter[2]),
                    };
                }
            }
        }
    }
}
