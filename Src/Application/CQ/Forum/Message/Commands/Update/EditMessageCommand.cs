namespace Application.CQ.Forum.Message.Commands.Update
{
    using MediatR;
    using System;

    public class EditMessageCommand : IRequest<string>
    {
        public string MessageId { get; set; }

        public string Content { get; set; }
    }
}
