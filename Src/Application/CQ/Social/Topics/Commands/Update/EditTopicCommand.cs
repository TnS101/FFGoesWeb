namespace Application.CQ.Social.Topics.Commands.Update
{
    using System.Security.Claims;
    using MediatR;

    public class EditTopicCommand : IRequest<string>
    {
        public string Id { get; set; }

        public string NewTitle { get; set; }

        public string NewCategory { get; set; }

        public string NewContent { get; set; }

        public string UserId { get; set; }
    }
}
