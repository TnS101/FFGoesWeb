﻿namespace Application.CQ.Social.Messages.Queries
{
    using System.Security.Claims;
    using MediatR;

    public class GetPersonalMessagesQuery : IRequest<MessageListViewModel>
    {
        public ClaimsPrincipal Reciever { get; set; }

        public string SenderId { get; set; }
    }
}