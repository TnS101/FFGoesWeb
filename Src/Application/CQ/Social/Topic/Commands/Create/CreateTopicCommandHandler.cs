namespace Application.CQ.Forum.Topic.Commands.Create
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using Domain.Entities.Common.Social;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class CreateTopicCommandHandler : PageModel, IRequestHandler<CreateTopicCommand, string[]>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public CreateTopicCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string[]> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var sb = new StringBuilder();

            if (this.ModelState.IsValid)
            {
                await this.context.Topics.AddAsync(new Domain.Entities.Common.Social.Topic
                {
                    Title = request.Title,
                    Category = request.Category,
                    Content = request.Content,
                    UserId = user.Id,
                    Comments = new List<Comment>(),
                    Likes = 0,
                    CreateOn = DateTime.UtcNow,
                });

                await this.context.SaveChangesAsync(cancellationToken);

                return new string[] { GConst.TopicCommandRedirect, string.Empty };
            }

            var errors = this.ModelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                sb.AppendLine(error.ErrorMessage);
            }

            return new string[] { GConst.CreateTopicErrorRedirect, sb.ToString() };
        }
    }
}
