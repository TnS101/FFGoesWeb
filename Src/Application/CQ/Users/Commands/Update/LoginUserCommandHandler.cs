﻿namespace Application.CQ.Users.Commands.Update
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand,string>
    {
        private readonly IFFDbContext context;
        private readonly SignInManager<User> signInManager;
        public LoginUserCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = this.context.Users.FirstOrDefault(u => u.Username == request.Username);

            var status = await this.signInManager.PasswordSignInAsync(user.Username, user.Username, true, false);

            if (status.Succeeded)
            {
                await signInManager.SignInAsync(user, true);
                return "Login Succesful";
            }
            else
            {
                return "An error occured. Please, try again!";
            }
        }
    }
}
