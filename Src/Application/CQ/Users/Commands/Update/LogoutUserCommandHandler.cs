﻿namespace Application.CQ.Users.Commands.Update
{
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System.Threading;
    using System.Threading.Tasks;

    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand>
    {
        private readonly SignInManager<User> signInManager;
        public LogoutUserCommandHandler (SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task<Unit> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            await this.signInManager.SignOutAsync();
            return Unit.Value;
        }
    }
}
