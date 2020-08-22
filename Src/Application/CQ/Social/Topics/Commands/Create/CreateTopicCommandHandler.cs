namespace Application.CQ.Social.Topics.Commands.Create
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Social;
    using MediatR;

    public class CreateTopicCommandHandler : BaseHandler, IRequestHandler<CreateTopicCommand>
    {
        public CreateTopicCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<Unit> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            this.Context.Topics.Add(new Topic
            {
                Title = request.Title,
                Category = request.Category,
                Content = request.Content,
                UserId = request.UserId,
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                CreateOn = DateTime.UtcNow,
            });

            await this.Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
